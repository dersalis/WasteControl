using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.WasteExports.AddTransporter
{
    internal sealed class AddTransporterCommandHandler : CommandHandlerBase, IRequestHandler<AddTransporterCommand>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<TransportCompany> _transportCompanyRepository;

        public AddTransporterCommandHandler(IRepository<WasteExport> wasteExportRepository, IUserRepository userRepository, IRepository<TransportCompany> transportCompanyRepository, IDateTimeProvider dateTimeProvider) : base(dateTimeProvider)
        {
            _wasteExportRepository = wasteExportRepository;
            _userRepository = userRepository;
            _transportCompanyRepository = transportCompanyRepository;
        }

        public async Task Handle(AddTransporterCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = await GetNowAsync();

            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;
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