using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.ReceivingCompanies.UpdateReceivingCompany
{
    public class UpdateReceivingCompanyCommandHandler : IRequestHandler<UpdateReceivingCompanyCommand>
    {
        private readonly IRepository<ReceivingCompany> _receivingCompanyRepository;
        private readonly IRepository<User> _userRepository;

        public UpdateReceivingCompanyCommandHandler(IRepository<ReceivingCompany> receivingCompanyRepository, IRepository<User> userRepository)
        {
            _receivingCompanyRepository = receivingCompanyRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateReceivingCompanyCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User

            if (user is null)
                throw new UserNotFoundException();

            ReceivingCompany company = await _receivingCompanyRepository.GetAsync(request.Id);

            if (company is null)
                throw new ReceivingCompanyNotFoundException();

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

            await _receivingCompanyRepository.UpdateAsync(company);
        }
    }
}