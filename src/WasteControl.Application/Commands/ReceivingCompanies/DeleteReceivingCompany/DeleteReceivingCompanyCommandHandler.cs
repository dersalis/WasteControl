using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.ReceivingCompanies.DeleteReceivingCompany
{
    public class DeleteReceivingCompanyCommandHandler : IRequestHandler<DeleteReceivingCompanyCommand>
    {
        private readonly IRepository<ReceivingCompany> _receivingCompanyRepository;
        private readonly IRepository<User> _userRepository;

        public DeleteReceivingCompanyCommandHandler(IRepository<ReceivingCompany> receivingCompanyRepository, IRepository<User> userRepository)
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