using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.Wastes.GetWastes
{
    public class GetWastesQuery : IRequest<IEnumerable<WasteDto>>
    {
    }
}