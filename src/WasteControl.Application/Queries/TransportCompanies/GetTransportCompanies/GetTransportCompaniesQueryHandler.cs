using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
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

            return companies.Select(c => c.MapToDto());
        }
        
    }
}