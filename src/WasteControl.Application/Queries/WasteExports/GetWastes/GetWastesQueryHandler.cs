using MediatR;
using WasteControl.Application.DTO;
using WasteControl.Core.Entities;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Application.Queries.WasteExports.GetWastes
{
    internal sealed class GetWastesQueryHandler : IRequestHandler<GetWastesQuery, IEnumerable<WasteDto>>
    {
        private readonly IRepository<WasteExport> _wasteRepository;
        private readonly IRepository<User> _userRepository;

        public GetWastesQueryHandler(IRepository<WasteExport> wasteRepository, IRepository<User> userRepository)
        {
            _wasteRepository = wasteRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<WasteDto>> Handle(GetWastesQuery request, CancellationToken cancellationToken)
        {
            var wastes = (await _wasteRepository.GetAsync(request.Id)).Wastes.ToList();
            var users = await _userRepository.GetAllAsync();

            return wastes.Select(w => 
            {
                var createdBy = users.FirstOrDefault(u => u.Id == w.CreatedById);
                var modifiedBy = users.FirstOrDefault(u => u.Id == w.ModifiedById);

                return new WasteDto
                {
                    Id = w.Id,
                    Code = w.Code.Value,
                    Name = w.Name.Value,
                    Quantity = w.Quantity.Value,
                    Unit = w.Unit.Value,
                    IsActive = w.IsActive,
                    CreateDate = w.CreateDate?.Value,
                    CreatedByName = createdBy is not null ? createdBy?.Name : "",
                    ModifiedDate = w.ModifiedDate?.Value,
                    ModifiedBy = modifiedBy is not null ? modifiedBy?.Name : "",
                };
            });
        }
    }
}