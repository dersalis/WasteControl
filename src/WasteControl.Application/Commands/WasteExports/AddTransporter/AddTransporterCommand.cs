using MediatR;

namespace WasteControl.Application.Commands.WasteExports.AddTransporter
{
    public class AddTransporterCommand : CommandBase, IRequest
    {
        public Guid WasteExportId { get; set; }
        public Guid TransporterId { get; set; }
    }
}