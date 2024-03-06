using WasteControl.Application.DTO;
using WasteControl.Core.Entities;

namespace WasteControl.Application.Mappers
{
    public static class CompanyMapper
    {
        public static CompanyDto MapToDto(this Company transportCompany)
        {
            return new CompanyDto
            {
                Id = transportCompany.Id,
                Code = transportCompany.Code.Value,
                Name = transportCompany.Name.Value,
                IsActive = transportCompany.IsActive,
                CreateDate = transportCompany.CreateDate?.Value,
                CreatedByName = transportCompany.CreatedBy is not null ? transportCompany.CreatedBy?.Name : "",
                ModifiedDate = transportCompany.ModifiedDate?.Value,
                ModifiedBy = transportCompany.ModifiedBy is not null ? transportCompany.ModifiedBy?.Name : "",
            };
        }
    }
}