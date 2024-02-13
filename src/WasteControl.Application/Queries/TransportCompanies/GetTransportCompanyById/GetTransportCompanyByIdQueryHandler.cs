using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.TransportCompanies.GetTransportCompanyById
{
    public class GetTransportCompanyByIdQueryHandler : IRequestHandler<GetTransportCompanyByIdQuery, CompanyDto>
    {
        private readonly IRepository<TransportCompany> _companyRepository;

        public GetTransportCompanyByIdQueryHandler(IRepository<TransportCompany> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDto> Handle(GetTransportCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetAsync(request.Id);

            return new CompanyDto
            {
                Id = company.Id,
                Code = company.Code.Value,
                Name = company.Name.Value,
                Address = company.Address.Value,
                City = company.City.Value,
                PostalCode = company.PostalCode.Value,
                Country = company.Country.Value,
                Phone = company.Phone.Value,
                Email = company.Email.Value,
                IsActive = company.IsActive,
                CreateDate = company.CreateDate?.Value,
                CreatedByName = company.CreateDate is not null ? company.CreatedBy?.Name : "",
                ModifiedDate = company.ModifiedDate?.Value,
                ModifiedBy = company.ModifiedBy is not null ? company.ModifiedBy?.Name : "",
            };
        }
    }
}