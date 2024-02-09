using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.Wastes.GetWasteById
{
    public class GetWasteByIdQuery : IRequest<WasteDto>
    {
        public Guid Id { get; set; }
    }
}