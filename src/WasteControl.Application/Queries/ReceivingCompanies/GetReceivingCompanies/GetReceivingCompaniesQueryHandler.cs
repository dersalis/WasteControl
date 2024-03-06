using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.ReceivingCompanies.GetReceivingCompanies
{
    internal sealed class GetReceivingCompaniesQueryHandler : IRequestHandler<GetReceivingCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IRepository<ReceivingCompany> _companyRepository;

        public GetReceivingCompaniesQueryHandler(IRepository<ReceivingCompany> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetReceivingCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllAsync();

            return companies.Select(c => c.MapToDto());
        }
        
    }
}