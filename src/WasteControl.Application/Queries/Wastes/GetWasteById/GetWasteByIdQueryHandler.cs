using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.Wastes.GetWasteById
{
    internal sealed class GetWasteByIdQueryHandler : IRequestHandler<GetWasteByIdQuery, WasteDto>
    {
        private readonly IRepository<Waste> _wasteRepository;
        private readonly IRepository<User> _userRepository;

        public GetWasteByIdQueryHandler(IRepository<Waste> wasteRepository, IRepository<User> userRepository)
        {
            _wasteRepository = wasteRepository;
            _userRepository = userRepository;
        }

        public async Task<WasteDto> Handle(GetWasteByIdQuery request, CancellationToken cancellationToken)
        {
            var waste = await _wasteRepository.GetAsync(request.Id);

            if (waste is null)
                return default;

            var createdBy = await _userRepository.GetAsync(waste.CreatedById);
            var modifiedBy = await _userRepository.GetAsync(waste.ModifiedById);

            return new WasteDto
            {
                Id = waste.Id,
                Code = waste.Code.Value,
                Name = waste.Name.Value,
                Quantity = waste.Quantity.Value,
                Unit = waste.Unit.Value,
                IsActive = waste.IsActive,
                CreateDate = waste.CreateDate?.Value,
                CreatedByName = createdBy is not null ? createdBy?.Name : "",
                ModifiedDate = waste.ModifiedDate?.Value,
                ModifiedBy = modifiedBy is not null ? modifiedBy?.Name : "",
            };
        }
    }
}