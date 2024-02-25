using MediatR;

namespace WasteControl.Application.Commands.WasteExports.AddReceiver
{
    public class AddReceiverCommand : IRequest
    {
        public Guid WasteExportId { get; set; }
        public Guid ReceiverId { get; set; }   
    }
}