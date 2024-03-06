using WasteControl.Application.DTO;
using WasteControl.Core.Entities;

namespace WasteControl.Application.Mappers
{
    public static class WasteExportMapper
    {
        public static WasteExportDto MapToDto(this WasteExport wasteExport)
        {
            return new WasteExportDto
            {
                Id = wasteExport.Id,
                ReceivingCompanyName = wasteExport.ReceivingCompany is not null ? 
                    $"[{wasteExport.ReceivingCompany?.Code}] {wasteExport.ReceivingCompany?.Name}" : "",
                TransportCompanyName = wasteExport.TransportCompany is not null ? 
                    $"[{wasteExport.TransportCompany?.Code}] {wasteExport.TransportCompany?.Name}" : "",
                BookingDate = wasteExport.BookingDate,
                Description = wasteExport.Description,
                Status = wasteExport.Status,
                IsActive = wasteExport.IsActive,
                CreateDate = wasteExport.CreateDate?.Value,
                CreatedByName = wasteExport.CreatedBy is not null ? wasteExport.CreatedBy?.Name : "",
                ModifiedDate = wasteExport.ModifiedDate?.Value,
                ModifiedBy = wasteExport.ModifiedBy is not null ? wasteExport.ModifiedBy?.Name : "",
            };
        }
    }
}