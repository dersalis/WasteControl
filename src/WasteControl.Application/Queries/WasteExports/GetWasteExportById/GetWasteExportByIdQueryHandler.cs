using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.WasteExports.GetWasteExportById
{
    internal sealed class GetWasteExportByIdQueryHandler : IRequestHandler<GetWasteExportByIdQuery, WasteExportDto>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;

        public GetWasteExportByIdQueryHandler(IRepository<WasteExport> wasteExportRepository)
        {
            _wasteExportRepository = wasteExportRepository;
        }

        public async Task<WasteExportDto> Handle(GetWasteExportByIdQuery request, CancellationToken cancellationToken)
        {
            var wasteExport = await _wasteExportRepository.GetAsync(request.Id);

            if (wasteExport is null)
                return default;

            return wasteExport.MapToDto();
        }
    }
}