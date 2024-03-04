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
                    ReceivingCompanyName = w.ReceivingCompany is not null ? 
                        $"[{w.ReceivingCompany?.Code}] {w.ReceivingCompany?.Name}" : "",
                    TransportCompanyName = w.TransportCompany is not null ? 
                        $"[{w.TransportCompany?.Code}] {w.TransportCompany?.Name}" : "",
                    BookingDate = w.BookingDate,
                    Description = w.Description,
                    Status = w.Status,
                    IsActive = w.IsActive,
                    CreateDate = w.CreateDate?.Value,
                    // CreatedByName = createdBy is not null ? createdBy?.Name : "",
                    CreatedByName = w.CreatedBy is not null ? w.CreatedBy?.Name : "",
                    ModifiedDate = w.ModifiedDate?.Value,
                    // ModifiedBy = modifiedBy is not null ? modifiedBy?.Name : "",
                    ModifiedBy = w.ModifiedBy is not null ? w.ModifiedBy?.Name : "",
                });
        }
    }
}