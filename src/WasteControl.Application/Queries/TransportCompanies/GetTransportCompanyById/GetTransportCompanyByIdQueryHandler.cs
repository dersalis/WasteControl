using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.TransportCompanies.GetTransportCompanyById
{
    internal sealed class GetTransportCompanyByIdQueryHandler : IRequestHandler<GetTransportCompanyByIdQuery, CompanyDto>
    {
        private readonly IRepository<TransportCompany> _companyRepository;

        public GetTransportCompanyByIdQueryHandler(IRepository<TransportCompany> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDto> Handle(GetTransportCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetAsync(request.Id);

            if (company is null)
                return default;

            return company.MapToDto();
        }
    }
}