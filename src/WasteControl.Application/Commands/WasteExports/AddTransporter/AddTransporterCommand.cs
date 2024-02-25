using MediatR;

namespace WasteControl.Application.Commands.WasteExports.AddTransporter
{
    public class AddTransporterCommand : IRequest
    {
        public Guid WasteExportId { get; set; }
        public Guid TransporterId { get; set; }
    }
}