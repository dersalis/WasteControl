using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.GetWastes
{
    public class GetWastesQueryHandler : IRequestHandler<GetWastesQuery, IEnumerable<WasteDto>>
    {
        private readonly IRepository<Waste> _wasteRepository;

        public GetWastesQueryHandler(IRepository<Waste> wasteRepository)
        {
            _wasteRepository = wasteRepository;
        }

        public async Task<IEnumerable<WasteDto>> Handle(GetWastesQuery request, CancellationToken cancellationToken)
        {
            var wastes = await _wasteRepository.GetAllAsync();

            return wastes.Select(w => new WasteDto
            {
                Id = w.Id,
                Code = w.Code.Value,
                Name = w.Name.Value,
                Quantity = w.Quantity.Value,
                Unit = w.Unit.Value,
                IsActive = w.IsActive,
                CreateDate = w.CreateDate,
                CreatedByName = w.CreatedBy?.Name,
                ModifiedDate = w.ModifiedDate,
                ModifiedBy = w.ModifiedBy?.Name,
            });
        }
    }
}