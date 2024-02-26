using MediatR;
using WasteControl.Application.DTO;
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

            return wasteExports.Select(w => new WasteExportDto
            {
                Id = w.Id,
                ReceivingCompanyName = w.ReceivingCompanyId is not null ? $"[{w.ReceivingCompanyId?.Code}] {w.ReceivingCompanyId?.Name}" : "",
                TransportCompanyName = w.TransportCompanyId is not null ? $"[{w.TransportCompanyId?.Code}] {w.TransportCompanyId?.Name}" : "",
                BookingDate = w.BookingDate,
                Description = w.Description,
                Status = w.Status,
                IsActive = w.IsActive,
                CreateDate = w.CreateDate?.Value,
                CreatedByName = w.CreateDate is not null ? w.CreatedBy?.Name : "",
                ModifiedDate = w.ModifiedDate?.Value,
                ModifiedBy = w.ModifiedBy is not null ? w.ModifiedBy?.Name : "",
            });
        }
    }
}