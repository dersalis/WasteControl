using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.TransportCompanies.DeleteTransportCompany
{
    internal sealed class DeleteTransportCompanyCommandHandler : IRequestHandler<DeleteTransportCompanyCommand>
    {
        private readonly IRepository<TransportCompany> _transportCompanyRepository;
        private readonly IRepository<User> _userRepository;

        public DeleteTransportCompanyCommandHandler(IRepository<TransportCompany> transportCompanyRepository, IRepository<User> userRepository)
        {
            _transportCompanyRepository = transportCompanyRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteTransportCompanyCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User

            if (user is null)
                throw new UserNotFoundException();

            TransportCompany transportCompany = await _transportCompanyRepository.GetAsync(request.Id);

            if (transportCompany is null)
                throw new TransportCompanyNotFoundException();

            transportCompany.ChangeActivity(false);
            transportCompany.ChangeModifiedDate(currentDate);
            transportCompany.ChangeModifiedBy(user);

            await _transportCompanyRepository.UpdateAsync(transportCompany);
        }
    }
}