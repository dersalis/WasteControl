using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.WasteExports.GetWastes
{
    public class GetWastesQuery : IRequest<IEnumerable<WasteDto>>
    {
        public Guid Id { get; set; }
    }
}