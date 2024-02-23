using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.WasteExports.GetWasteExports
{
    public class GetWasteExportsQuery : IRequest<IEnumerable<WasteExportDto>>
    {
    }
}