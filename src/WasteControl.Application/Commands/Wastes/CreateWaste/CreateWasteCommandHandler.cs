using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Wastes.CreateWaste
{
    internal sealed class CreateWasteCommandHandler : IRequestHandler<CreateWasteCommand, Guid>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Waste> _wasteRepository;

        public CreateWasteCommandHandler(IRepository<User> userRepository, IRepository<Waste> wasteRepository)
        {
            _userRepository = userRepository;
            _wasteRepository = wasteRepository;
        }

        public async Task<Guid> Handle(CreateWasteCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = (await _userRepository.GetAllAsync()).FirstOrDefault(); //TODO: Zmienic User

            if (user is null)
                throw new UserNotFoundException();

            Waste waste = new Waste(request.Code, request.Name, request.Quantity, request.Unit);
            waste.ChangeCreateDate(currentDate);
            waste.ChangeCreatedBy(user);

            await _wasteRepository.AddAsync(waste);

            return waste.Id;
        }
    }
}