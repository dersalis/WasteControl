using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.WasteExports.GetWasteExportById
{
    public class GetWasteExportByIdQueryHandler : IRequestHandler<GetWasteExportByIdQuery, WasteExportDto>
    {
        private readonly IRepository<WasteExport> _wasteExportRepository;

        public GetWasteExportByIdQueryHandler(IRepository<WasteExport> wasteExportRepository)
        {
            _wasteExportRepository = wasteExportRepository;
        }

        public async Task<WasteExportDto> Handle(GetWasteExportByIdQuery request, CancellationToken cancellationToken)
        {
            var wasteExport = await _wasteExportRepository.GetAsync(request.Id);

            return new WasteExportDto
            {
                Id = wasteExport.Id,
                ReceivingCompanyName = wasteExport.ReceivingCompany is not null ? $"[{wasteExport.ReceivingCompany?.Code}] {wasteExport.ReceivingCompany?.Name}" : "",
                TransportCompanyName = wasteExport.TransportCompany is not null ? $"[{wasteExport.TransportCompany?.Code}] {wasteExport.TransportCompany?.Name}" : "",
                BookingDate = wasteExport.BookingDate,
                Description = wasteExport.Description,
                Status = wasteExport.Status,
                IsActive = wasteExport.IsActive,
                CreateDate = wasteExport.CreateDate?.Value,
                CreatedByName = wasteExport.CreateDate is not null ? wasteExport.CreatedBy?.Name : "",
                ModifiedDate = wasteExport.ModifiedDate?.Value,
                ModifiedBy = wasteExport.ModifiedBy is not null ? wasteExport.ModifiedBy?.Name : "",
            };
        }
    }
}