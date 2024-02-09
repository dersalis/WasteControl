using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.Wastes.GetWasteById
{
    internal class GetWasteByIdQueryHandler : IRequestHandler<GetWasteByIdQuery, WasteDto>
    {
        private readonly IRepository<Waste> _wasteRepository;
        
        public GetWasteByIdQueryHandler(IRepository<Waste> wasteRepository)
        {
            _wasteRepository = wasteRepository;
        }

        public async Task<WasteDto> Handle(GetWasteByIdQuery request, CancellationToken cancellationToken)
        {
            var waste = await _wasteRepository.GetAsync(request.Id);

            return new WasteDto
            {
                Id = waste.Id,
                Code = waste.Code.Value,
                Name = waste.Name.Value,
                Quantity = waste.Quantity.Value,
                Unit = waste.Unit.Value,
                IsActive = waste.IsActive,
                CreateDate = waste.CreateDate?.Value,
                CreatedByName = waste.CreateDate is not null ? waste.CreatedBy?.Name : "",
                ModifiedDate = waste.ModifiedDate?.Value,
                ModifiedBy = waste.ModifiedBy is not null ? waste.ModifiedBy?.Name : "",
            };
        }
    }
}