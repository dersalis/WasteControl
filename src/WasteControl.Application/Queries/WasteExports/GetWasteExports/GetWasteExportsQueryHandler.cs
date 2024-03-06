using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.WasteExports.GetWasteExports
{
    internal sealed class GetWasteExportsQueryHandler : IRequestHandler<GetWasteExportsQuery, IEnumerable<WasteExportDto>>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;

        public GetWasteExportsQueryHandler(IRepository<WasteExport> wasteExportRepository)
        {
            _wasteExportRepository = wasteExportRepository;
        }

        public async Task<IEnumerable<WasteExportDto>> Handle(GetWasteExportsQuery request, CancellationToken cancellationToken)
        {
            var wasteExports = await _wasteExportRepository.GetAllAsync();

            return wasteExports.Select(w => w.MapToDto());
        }
    }
}