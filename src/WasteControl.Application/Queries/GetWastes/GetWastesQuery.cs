using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.GetWastes
{
    public class GetWastesQuery : IRequest<IEnumerable<WasteDto>>
    {
    }
}