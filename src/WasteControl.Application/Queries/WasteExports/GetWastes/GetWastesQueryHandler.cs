using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.WasteExports.GetWastes
{
    internal sealed class GetWastesQueryHandler : IRequestHandler<GetWastesQuery, IEnumerable<WasteDto>>
    {
        private readonly IRepository<WasteExport> _wasteRepository;

        public GetWastesQueryHandler(IRepository<WasteExport> wasteRepository)
        {
            _wasteRepository = wasteRepository;
        }

        public async Task<IEnumerable<WasteDto>> Handle(GetWastesQuery request, CancellationToken cancellationToken)
        {
            var wastes = (await _wasteRepository.GetAsync(request.Id)).Wastes.ToList();

            return wastes.Select(w => w.MapToDto());
        }
    }
}