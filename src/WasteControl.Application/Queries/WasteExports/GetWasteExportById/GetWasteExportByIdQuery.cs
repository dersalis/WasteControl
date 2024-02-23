using MediatR;
using WasteControl.Application.DTO;

namespace WasteControl.Application.Queries.WasteExports.GetWasteExportById
{
    public class GetWasteExportByIdQuery : IRequest<WasteExportDto>
    {
        public Guid Id { get; set; }
    }
}