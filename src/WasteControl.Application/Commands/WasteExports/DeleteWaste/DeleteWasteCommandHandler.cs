using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.WasteExports.DeleteWaste
{
    internal sealed class DeleteWasteCommandHandler : IRequestHandler<DeleteWasteCommand>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Waste> _wasteRepository;

        public DeleteWasteCommandHandler(IRepository<WasteExport> wasteExportRepository, IUserRepository userRepository, IRepository<Waste> wasteRepository)
        {
            _wasteExportRepository = wasteExportRepository;
            _userRepository = userRepository;
            _wasteRepository = wasteRepository;
        }

        public async Task Handle(DeleteWasteCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;

            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;
            if (user is null)
                throw new UserNotFoundException();

            WasteExport wasteExport = await _wasteExportRepository.GetAsync(request.WasteExportId);
            if (wasteExport is null)
                throw new WasteExportNotFoundException();

            Waste waste = await _wasteRepository.GetAsync(request.WasteId);

            if (waste is null)
                throw new WasteNotFoundException();

            wasteExport.DeleteWaste(waste);

            wasteExport.ChangeModifiedDate(currentDate);
            wasteExport.ChangeModifiedBy(user);

            await _wasteExportRepository.UpdateAsync(wasteExport);
        }
    }
}