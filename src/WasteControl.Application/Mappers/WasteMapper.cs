using WasteControl.Application.DTO;
using WasteControl.Core.Entities;

namespace WasteControl.Application.Mappers
{
    public static class WasteMapper
    {
        public static WasteDto MapToDto(this Waste waste)
        {
            return new WasteDto
            {
                Id = waste.Id,
                Code = waste.Code.Value,
                Name = waste.Name.Value,
                Quantity = waste.Quantity.Value,
                Unit = waste.Unit.Value,
                IsActive = waste.IsActive,
                CreateDate = waste.CreateDate?.Value,
                CreatedByName = waste.CreatedBy is not null ? waste.CreatedBy?.Name : "",
                ModifiedDate = waste.ModifiedDate?.Value,
                ModifiedBy = waste.ModifiedBy is not null ? waste.ModifiedBy?.Name : "",
            };
        }
    }
}