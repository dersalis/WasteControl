using MediatR;

namespace WasteControl.Application.Commands.WasteExports.DeleteWaste
{
    public class DeleteWasteCommand : IRequest
    {
        public Guid WasteExportId { get; set; }
        public Guid WasteId { get; set; }
    }
}