using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Wastes.CreateWaste
{
    internal sealed class CreateWasteCommandHandler :  CommandHandlerBase, IRequestHandler<CreateWasteCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Waste> _wasteRepository;

        public CreateWasteCommandHandler(IUserRepository userRepository, IRepository<Waste> wasteRepository, IDateTimeProvider dateTimeProvider) : base(dateTimeProvider)
        {
            _userRepository = userRepository;
            _wasteRepository = wasteRepository;
        }

        public async Task<Guid> Handle(CreateWasteCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = await GetNowAsync();
            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;

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