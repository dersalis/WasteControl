using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.WasteExports.AddWastes
{
    internal sealed class AddWastesCommandHandler : IRequestHandler<AddWastesCommand>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Waste> _wasteRepository;

        public AddWastesCommandHandler(IRepository<WasteExport> wasteExportRepository, IRepository<User> userRepository, IRepository<Waste> wasteRepository)
        {
            _wasteExportRepository = wasteExportRepository;
            _userRepository = userRepository;
            _wasteRepository = wasteRepository;
        }
        
        public async Task Handle(AddWastesCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;

            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User
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