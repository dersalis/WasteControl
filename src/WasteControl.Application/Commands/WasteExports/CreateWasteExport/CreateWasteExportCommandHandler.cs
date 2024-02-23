using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Core.Enums;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.WasteExports.CreateWasteExport
{
    public class CreateWasteExportCommandHandler : IRequestHandler<CreateWasteExportCommand, Guid>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ReceivingCompany> _receivingCompanyRepository;
        private readonly IRepository<TransportCompany> _transportCompanyRepository;

        public CreateWasteExportCommandHandler(IRepository<WasteExport> wasteExportRepository, IRepository<User> userRepository, IRepository<ReceivingCompany> receivingCompanyRepository, IRepository<TransportCompany> transportCompanyRepository)
        {
            _wasteExportRepository = wasteExportRepository;
            _userRepository = userRepository;
            _receivingCompanyRepository = receivingCompanyRepository;
            _transportCompanyRepository = transportCompanyRepository;
        }

        public async Task<Guid> Handle(CreateWasteExportCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;

            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User
            if (user is null)
                throw new UserNotFoundException();

            ReceivingCompany receivingCompany = await _receivingCompanyRepository.GetAsync(request.ReceivingCompanyOid);
            if(receivingCompany is null)
                throw new ReceivingCompanyNotFoundException();

            TransportCompany transportCompany = await _transportCompanyRepository.GetAsync(request.TransportCompanyOid);
            if(transportCompany is null)
                throw new TransportCompanyNotFoundException();

            WasteExport wasteExport = new WasteExport(receivingCompany, transportCompany, 
                request.BookingDate, request.Description, WasteExportStatus.Waiting);
            wasteExport.ChangeCreateDate(currentDate);
            wasteExport.ChangeCreatedBy(user);

            await _wasteExportRepository.AddAsync(wasteExport);

            return wasteExport.Id;
        }
    }
}