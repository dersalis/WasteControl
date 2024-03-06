using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Application.Mappers;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.Wastes.GetWasteById
{
    internal sealed class GetWasteByIdQueryHandler : IRequestHandler<GetWasteByIdQuery, WasteDto>
    {
        private readonly IRepository<Waste> _wasteRepository;

        public GetWasteByIdQueryHandler(IRepository<Waste> wasteRepository)
        {
            _wasteRepository = wasteRepository;
        }

        public async Task<WasteDto> Handle(GetWasteByIdQuery request, CancellationToken cancellationToken)
        {
            var waste = await _wasteRepository.GetAsync(request.Id);

            if (waste is null)
                return default;

            return waste.MapToDto();
        }
    }
}