using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.TransportCompanies.CreateTransportCompany
{
    internal sealed class CreateTransportCompanyCommandHandler : IRequestHandler<CreateTransportCompanyCommand, Guid>
    {
        public readonly IRepository<TransportCompany> _transportCompanyRepository;
        public readonly IUserRepository _userRepository;

        public CreateTransportCompanyCommandHandler(IRepository<TransportCompany> transportCompanyRepository, IUserRepository userRepository)
        {
            _transportCompanyRepository = transportCompanyRepository;
            _userRepository = userRepository;
        }
        
        public async Task<Guid> Handle(CreateTransportCompanyCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User

            if (user is null)
                throw new UserNotFoundException();

            TransportCompany company = new TransportCompany(request.Code, request.Name, request.Address, request.City, request.PostalCode, request.Country, request.Phone, request.Email);
            company.ChangeCreateDate(currentDate);
            company.ChangeCreatedBy(user);

            await _transportCompanyRepository.AddAsync(company);

            return company.Id;
        }
    }
}