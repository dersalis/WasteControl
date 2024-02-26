using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Wastes.DeleteWaste
{
    internal sealed class DeleteWasteCommandHandler : IRequestHandler<DeleteWasteCommand>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Waste> _wasteRepository;

        public DeleteWasteCommandHandler(IRepository<User> userRepository, IRepository<Waste> wasteRepository)
        {
            _userRepository = userRepository;
            _wasteRepository = wasteRepository;
        }
        
        public async Task Handle(DeleteWasteCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User

            if (user is null)
                throw new UserNotFoundException();

            Waste waste = await _wasteRepository.GetAsync(request.Id);

            if (waste is null)
                throw new WasteNotFoundException();

            waste.ChangeActivity(false);
            waste.ChangeModifiedDate(currentDate);
            waste.ChangeModifiedBy(user);

            await _wasteRepository.UpdateAsync(waste);
        }
    }
}