using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.WasteExports.GetWastes
{
    internal sealed class GetWastesQueryHandler : IRequestHandler<GetWastesQuery, IEnumerable<WasteDto>>
    {
        private readonly IRepository<WasteExport> _wasteRepository;

        public GetWastesQueryHandler(IRepository<WasteExport> wasteRepository)
        {
            _wasteRepository = wasteRepository;
        }

        public async Task<IEnumerable<WasteDto>> Handle(GetWastesQuery request, CancellationToken cancellationToken)
        {
            var wastes = (await _wasteRepository.GetAsync(request.Id)).Wastes.ToList();

            return wastes.Select(w => 
            {

                return new WasteDto
                {
                    Id = w.Id,
                    Code = w.Code.Value,
                    Name = w.Name.Value,
                    Quantity = w.Quantity.Value,
                    Unit = w.Unit.Value,
                    IsActive = w.IsActive,
                    CreateDate = w.CreateDate?.Value,
                    CreatedByName = w.CreatedBy is not null ? w.CreatedBy?.Name : "",
                    ModifiedDate = w.ModifiedDate?.Value,
                    ModifiedBy = w.ModifiedBy is not null ? w.ModifiedBy?.Name : "",
                };
            });
        }
    }
}