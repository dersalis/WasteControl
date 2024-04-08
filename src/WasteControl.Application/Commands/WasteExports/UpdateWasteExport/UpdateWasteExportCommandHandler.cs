using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.WasteExports.UpdateWasteExport
{
    internal sealed class UpdateWasteExportCommandHandler : IRequestHandler<UpdateWasteExportCommand>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<ReceivingCompany> _receivingCompanyRepository;
        private readonly IRepository<TransportCompany> _transportCompanyRepository;

        public UpdateWasteExportCommandHandler(IRepository<WasteExport> wasteExportRepository, IUserRepository userRepository, IRepository<ReceivingCompany> receivingCompanyRepository, IRepository<TransportCompany> transportCompanyRepository)
        {
            _wasteExportRepository = wasteExportRepository;
            _userRepository = userRepository;
            _receivingCompanyRepository = receivingCompanyRepository;
            _transportCompanyRepository = transportCompanyRepository;
        }
        
        public async Task Handle(UpdateWasteExportCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;

            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;
            if (user is null)
                throw new UserNotFoundException();

            ReceivingCompany receivingCompany = await _receivingCompanyRepository.GetAsync(request.ReceivingCompanyOid);
            if(receivingCompany is null)
                throw new ReceivingCompanyNotFoundException();

            TransportCompany transportCompany = await _transportCompanyRepository.GetAsync(request.TransportCompanyOid);
            if(transportCompany is null)
                throw new TransportCompanyNotFoundException();

            WasteExport wasteExport = await _wasteExportRepository.GetAsync(request.Id);
            if(wasteExport is null)
                throw new WasteExportNotFoundException();

            wasteExport.AddReceivingCompany(receivingCompany);
            wasteExport.AddTransportCompany(transportCompany);
            wasteExport.ChangeBookingDate(request.BookingDate);
            wasteExport.ChangeDescription(request.Description);
            wasteExport.ChangeModifiedDate(currentDate);
            wasteExport.ChangeModifiedBy(user);

            await _wasteExportRepository.UpdateAsync(wasteExport);
        }
    }
}