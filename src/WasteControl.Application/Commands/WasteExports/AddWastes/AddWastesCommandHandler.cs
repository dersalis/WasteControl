using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.WasteExports.AddWastes
{
    internal sealed class AddWastesCommandHandler : CommandHandlerBase, IRequestHandler<AddWastesCommand>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Waste> _wasteRepository;

        public AddWastesCommandHandler(IRepository<WasteExport> wasteExportRepository, IUserRepository userRepository, IRepository<Waste> wasteRepository, IDateTimeProvider dateTimeProvider) : base(dateTimeProvider)
        {
            _wasteExportRepository = wasteExportRepository;
            _userRepository = userRepository;
            _wasteRepository = wasteRepository;
        }
        
        public async Task Handle(AddWastesCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = await GetNowAsync();

            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;
            if (user is null)
                throw new UserNotFoundException();

            List<Waste> wastes = (await _wasteRepository.GetAllAsync())
                .Where(w => request.Wastes.Contains(w.Id)).ToList();

            if (wastes.Count > 0)
            {
                WasteExport wasteExport = await _wasteExportRepository.GetAsync(request.WasteExportId);
                if (wasteExport is null)
                    throw new WasteExportNotFoundException();

                foreach (var waste in wastes)
                {
                    wasteExport.AddWaste(waste);
                }

                wasteExport.ChangeModifiedDate(currentDate);
                wasteExport.ChangeModifiedBy(user);

                await _wasteExportRepository.UpdateAsync(wasteExport);
            }
        }
    }
}