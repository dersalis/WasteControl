using MediatR;
using WasteControl.Application.Exceptions;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Commands.Wastes.UpdateWaste
{
    internal sealed class UpdateWasteCommandHandler : IRequestHandler<UpdateWasteCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Waste> _wasteRepository;

        public UpdateWasteCommandHandler(IUserRepository userRepository, IRepository<Waste> wasteRepository)
        {
            _userRepository = userRepository;
            _wasteRepository = wasteRepository;
        }
        
        public async Task Handle(UpdateWasteCommand request, CancellationToken cancellationToken)
        {
            DateTime currentDate = DateTime.Now;
            User user = request.UserId.HasValue ? await _userRepository.GetByIdAsync(request.UserId.Value) : null;

            if (user is null)
                throw new UserNotFoundException();

            Waste waste = await _wasteRepository.GetAsync(request.Id);

            if (waste is null)
                throw new WasteNotFoundException();

            waste.ChangeCode(request.Code);
            waste.ChangeName(request.Name);
            waste.ChangeQuantity(request.Quantity);
            waste.ChangeUnit(request.Unit);
            waste.ChangeModifiedDate(currentDate);
            waste.ChangeModifiedBy(user);
            
            await _wasteRepository.UpdateAsync(waste);
        }
    }
}