using MediatR;

namespace WasteControl.Application.Commands.WasteExports.DeleteWasteExport
{
    public class DeleteWasteExportCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}