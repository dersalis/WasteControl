using MediatR;

namespace WasteControl.Application.Commands.WasteExports.AddReceiver
{
    public class AddReceiverCommand : CommandBase, IRequest
    {
        public Guid WasteExportId { get; set; }
        public Guid ReceiverId { get; set; }   
    }
}