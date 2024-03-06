using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.ReceivingCompanies.GetReceivingCompanyById
{
    internal sealed class GetReceivingCompanyByIdQueryHandler : IRequestHandler<GetReceivingCompanyByIdQuery, CompanyDto>
    {
        private readonly IRepository<ReceivingCompany> _companyRepository;

        public GetReceivingCompanyByIdQueryHandler(IRepository<ReceivingCompany> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDto> Handle(GetReceivingCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetAsync(request.Id);

            if (company is null)
                return default;

            return company.MapToDto();
        }
    }
}