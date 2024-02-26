using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.WasteExports.AddTransporter
{
    internal sealed class AddTransporterCommandHandler : IRequestHandler<AddTransporterCommand>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<TransportCompany> _transportCompanyRepository;

        public AddTransporterCommandHandler(IRepository<WasteExport> wasteExportRepository, IRepository<User> userRepository, IRepository<TransportCompany> transportCompanyRepository)
        {
            _wasteExportRepository = wasteExportRepository;
            _userRepository = userRepository;
            _transportCompanyRepository = transportCompanyRepository;
        }

        public async Task Handle(AddTransporterCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;

            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User
            if (user is null)
                throw new UserNotFoundException();

            TransportCompany transportCompany = await _transportCompanyRepository.GetAsync(request.TransporterId);
            if(transportCompany is null)
                throw new ReceivingCompanyNotFoundException();

            WasteExport wasteExport = await _wasteExportRepository.GetAsync(request.WasteExportId);
            if (wasteExport is null)
                throw new WasteExportNotFoundException();

            wasteExport.AddTransportCompany(transportCompany);

            wasteExport.ChangeModifiedDate(currentDate);
            wasteExport.ChangeModifiedBy(user);

            await _wasteExportRepository.UpdateAsync(wasteExport);
        }
    }
}