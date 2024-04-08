using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.ReceivingCompanies.CreateReceivingCompany
{
    internal sealed class CreateReceivingCompanyCommandHandler : IRequestHandler<CreateReceivingCompanyCommand, Guid>
    {
        public readonly IRepository<ReceivingCompany> _receivingCompanyRepository;
        public readonly IUserRepository _userRepository;

        public CreateReceivingCompanyCommandHandler(IRepository<ReceivingCompany> receivingCompanyRepository, IUserRepository userRepository)
        {
            _receivingCompanyRepository = receivingCompanyRepository;
            _userRepository = userRepository;
        }
        
        public async Task<Guid> Handle(CreateReceivingCompanyCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;

            if (user is null)
                throw new UserNotFoundException();

            ReceivingCompany company = new ReceivingCompany(request.Code, request.Name, request.Address, request.City, request.PostalCode, request.Country, request.Phone, request.Email);
            company.ChangeCreateDate(currentDate);
            company.ChangeCreatedBy(user);

            await _receivingCompanyRepository.AddAsync(company);

            return company.Id;
        }
    }
}