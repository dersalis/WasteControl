using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.WasteExports.AddReceiver
{
    internal sealed class AddReceiverCommandHandler : IRequestHandler<AddReceiverCommand>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<ReceivingCompany> _receivingCompanyRepository;

        public AddReceiverCommandHandler(IRepository<WasteExport> wasteExportRepository, IUserRepository userRepository, IRepository<ReceivingCompany> receivingCompanyRepository)
        {
            _wasteExportRepository = wasteExportRepository;
            _userRepository = userRepository;
            _receivingCompanyRepository = receivingCompanyRepository;
        }

        public async Task Handle(AddReceiverCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;

            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;
            if (user is null)
                throw new UserNotFoundException();

            ReceivingCompany receivingCompany = await _receivingCompanyRepository.GetAsync(request.ReceiverId);
            if(receivingCompany is null)
                throw new ReceivingCompanyNotFoundException();

            WasteExport wasteExport = await _wasteExportRepository.GetAsync(request.WasteExportId);
            if (wasteExport is null)
                throw new WasteExportNotFoundException();

            wasteExport.AddReceivingCompany(receivingCompany);

            wasteExport.ChangeModifiedDate(currentDate);
            wasteExport.ChangeModifiedBy(user);

            await _wasteExportRepository.UpdateAsync(wasteExport);
        }
    }
}