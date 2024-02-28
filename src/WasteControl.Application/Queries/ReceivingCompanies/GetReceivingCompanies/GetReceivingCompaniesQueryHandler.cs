using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.ReceivingCompanies.GetReceivingCompanies
{
    internal sealed class GetReceivingCompaniesQueryHandler : IRequestHandler<GetReceivingCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IRepository<ReceivingCompany> _companyRepository;
        private readonly IRepository<User> _userRepository;

        public GetReceivingCompaniesQueryHandler(IRepository<ReceivingCompany> companyRepository, IRepository<User> userRepository)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetReceivingCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllAsync();
            var users = await _userRepository.GetAllAsync();

            return companies.Select(c => 
            {
                var createdBy = users.FirstOrDefault(u => u.Id == c.CreatedById);
                var modifiedBy = users.FirstOrDefault(u => u.Id == c.ModifiedById);

                return new CompanyDto
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
                    CreatedByName = createdBy is not null ? createdBy?.Name : "",
                    ModifiedDate = c.ModifiedDate?.Value,
                    ModifiedBy = modifiedBy is not null ? modifiedBy?.Name : "",
                };
            });
        }
        
    }
}