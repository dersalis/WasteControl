using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.WasteExports.DeleteWasteExport
{
    public class DeleteWasteExportHandler : IRequestHandler<DeleteWasteExportCommand>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IRepository<User> _userRepository;

        public DeleteWasteExportHandler(IRepository<User> userRepository, IRepository<WasteExport> wasteExportRepository)
        {
            _userRepository = userRepository;
            _wasteExportRepository = wasteExportRepository;
        }

        public async Task Handle(DeleteWasteExportCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User

            if (user is null)
                throw new UserNotFoundException();

            WasteExport wasteExport = await _wasteExportRepository.GetAsync(request.Id);
            if (wasteExport is null)
                throw new WasteExportNotFoundException();

            wasteExport.ChangeActivity(false);
            wasteExport.ChangeModifiedDate(currentDate);
            wasteExport.ChangeModifiedBy(user);

            await _wasteExportRepository.UpdateAsync(wasteExport);
        }
    }
}