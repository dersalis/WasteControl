using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.TransportCompanies.GetTransportCompanyById
{
    internal sealed class GetTransportCompanyByIdQueryHandler : IRequestHandler<GetTransportCompanyByIdQuery, CompanyDto>
    {
        private readonly IRepository<TransportCompany> _companyRepository;
        private readonly IRepository<User> _userRepository;

        public GetTransportCompanyByIdQueryHandler(IRepository<TransportCompany> companyRepository, IRepository<User> userRepository)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        public async Task<CompanyDto> Handle(GetTransportCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetAsync(request.Id);

            if (company is null)
                return default;

            var createdBy = await _userRepository.GetAsync(company.CreatedById);
            var modifiedBy = await _userRepository.GetAsync(company.ModifiedById);

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
                CreatedByName = createdBy is not null ? createdBy?.Name : "",
                ModifiedDate = company.ModifiedDate?.Value,
                ModifiedBy = modifiedBy is not null ? modifiedBy?.Name : "",
            };
        }
    }
}