using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Wastes.DeleteWaste
{
    internal sealed class DeleteWasteCommandHandler : CommandHandlerBase, IRequestHandler<DeleteWasteCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Waste> _wasteRepository;

        public DeleteWasteCommandHandler(IUserRepository userRepository, IRepository<Waste> wasteRepository, IDateTimeProvider dateTimeProvider) : base(dateTimeProvider)
        {
            _userRepository = userRepository;
            _wasteRepository = wasteRepository;
        }
        
        public async Task Handle(DeleteWasteCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = await GetNowAsync();
            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;

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