using MediatR;

namespace WasteControl.Application.Commands.WasteExports.AddWastes
{
    public class AddWastesCommand : IRequest
    {
        public Guid WasteExportId { get; set; }
        public Guid[] Wastes { get; set; }
    }
}