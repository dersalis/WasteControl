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

        public GetWastesQueryHandler(IRepository<Waste> wasteRepository)
        {
            _wasteRepository = wasteRepository;
        }

        public async Task<IEnumerable<WasteDto>> Handle(GetWastesQuery request, CancellationToken cancellationToken)
        {
            var wastes = await _wasteRepository.GetAllAsync();

            return wastes.Select(w => w.MapToDto());
        }
    }
}