using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.TransportCompanies.UpdateTransportCompany
{
    public class UpdateTransportCompanyCommandHandler : IRequestHandler<UpdateTransportCompanyCommand>
    {
        private readonly IRepository<TransportCompany> _transportCompanyRepository;
        private readonly IRepository<User> _userRepository;
        
        public UpdateTransportCompanyCommandHandler(IRepository<TransportCompany> transportCompanyRepository, IRepository<User> userRepository)
        {
            _transportCompanyRepository = transportCompanyRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateTransportCompanyCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User

            if (user is null)
                throw new UserNotFoundException();

            TransportCompany company = await _transportCompanyRepository.GetAsync(request.Id);

            if (company is null)
                throw new TransportCompanyNotFoundException();

            company.ChangeCompanyCode(request.Code);
            company.ChangeCompanyName(request.Name);
            company.ChangeAddress(request.Address);
            company.ChangeCity(request.City);
            company.ChangePostalCode(request.PostalCode);
            company.ChangeCountry(request.Country);
            company.ChangePhone(request.Phone);
            company.ChangeEmail(request.Email);
            company.ChangeModifiedDate(currentDate);
            company.ChangeModifiedBy(user);

            await _transportCompanyRepository.UpdateAsync(company);
        }
    }
}