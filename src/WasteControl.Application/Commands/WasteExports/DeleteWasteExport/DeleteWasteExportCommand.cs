using MediatR;

namespace WasteControl.Application.Commands.WasteExports.DeleteWasteExport
{
    public class DeleteWasteExportCommand : CommandBase, IRequest
    {
        public Guid Id { get; set; }
    }
}