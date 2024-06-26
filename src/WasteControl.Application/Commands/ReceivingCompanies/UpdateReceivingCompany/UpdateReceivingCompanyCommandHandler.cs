using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.ReceivingCompanies.UpdateReceivingCompany
{
    internal sealed class UpdateReceivingCompanyCommandHandler : IRequestHandler<UpdateReceivingCompanyCommand>
    {
        private readonly IRepository<ReceivingCompany> _receivingCompanyRepository;
        private readonly IUserRepository _userRepository;

        public UpdateReceivingCompanyCommandHandler(IRepository<ReceivingCompany> receivingCompanyRepository, IUserRepository userRepository)
        {
            _receivingCompanyRepository = receivingCompanyRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateReceivingCompanyCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;

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