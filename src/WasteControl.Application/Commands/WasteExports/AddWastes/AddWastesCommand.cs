using MediatR;

namespace WasteControl.Application.Commands.WasteExports.AddWastes
{
    public class AddWastesCommand : CommandBase, IRequest
    {
        public Guid WasteExportId { get; set; }
        public Guid[] Wastes { get; set; }
    }
}