using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.Wastes.GetWastes
{
    internal sealed class GetWastesQueryHandler : IRequestHandler<GetWastesQuery, IEnumerable<WasteDto>>
    {
        private readonly IRepository<Waste> _wasteRepository;
        private readonly IRepository<User> _userRepository;

        public GetWastesQueryHandler(IRepository<Waste> wasteRepository, IRepository<User> userRepository)
        {
            _wasteRepository = wasteRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<WasteDto>> Handle(GetWastesQuery request, CancellationToken cancellationToken)
        {
            var wastes = await _wasteRepository.GetAllAsync();
            var users = await _userRepository.GetAllAsync();

            return wastes.Select(w => w.MapToDto());
        }
    }
}