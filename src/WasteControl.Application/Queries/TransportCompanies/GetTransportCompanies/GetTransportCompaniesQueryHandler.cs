using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.TransportCompanies.GetTransportCompanies
{
    internal sealed class GetTransportCompaniesQueryHandler : IRequestHandler<GetTransportCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IRepository<TransportCompany> _companyRepository;
        public GetTransportCompaniesQueryHandler(IRepository<TransportCompany> companyRepository)
        {
            _companyRepository = companyRepository;
        }
        
        public async Task<IEnumerable<CompanyDto>> Handle(GetTransportCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllAsync();

            return companies.Select(c => new CompanyDto
            {
                Id = c.Id,
                Code = c.Code.Value,
                Name = c.Name.Value,
                Address = c.Address.Value,
                City = c.City.Value,
                PostalCode = c.PostalCode.Value,
                Country = c.Country.Value,
                Phone = c.Phone.Value,
                Email = c.Email.Value,
                IsActive = c.IsActive,
                CreateDate = c.CreateDate?.Value,
                CreatedByName = c.CreateDate is not null ? c.CreatedBy?.Name : "",
                ModifiedDate = c.ModifiedDate?.Value,
                ModifiedBy = c.ModifiedBy is not null ? c.ModifiedBy?.Name : "",
            });
        }
        
    }
}