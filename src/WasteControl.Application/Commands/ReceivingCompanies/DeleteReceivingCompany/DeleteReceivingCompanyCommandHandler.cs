using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.ReceivingCompanies.DeleteReceivingCompany
{
    internal sealed class DeleteReceivingCompanyCommandHandler : IRequestHandler<DeleteReceivingCompanyCommand>
    {
        private readonly IRepository<ReceivingCompany> _receivingCompanyRepository;
        private readonly IUserRepository _userRepository;

        public DeleteReceivingCompanyCommandHandler(IRepository<ReceivingCompany> receivingCompanyRepository, IUserRepository userRepository)
        {
            _receivingCompanyRepository = receivingCompanyRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteReceivingCompanyCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User

            if (user is null)
                throw new UserNotFoundException();

            ReceivingCompany receivingCompany = await _receivingCompanyRepository.GetAsync(request.Id);

            if (receivingCompany is null)
                throw new ReceivingCompanyNotFoundException();

            receivingCompany.ChangeActivity(false);
            receivingCompany.ChangeModifiedDate(currentDate);
            receivingCompany.ChangeModifiedBy(user);

            await _receivingCompanyRepository.UpdateAsync(receivingCompany);
        }
    }
}