using MediatR;

namespace WasteControl.Application.Commands.WasteExports.UpdateWasteExport
{
    public class UpdateWasteExportCommand : CommandBase, IRequest
    {
        public Guid Id { get; set; }
        public Guid ReceivingCompanyOid { get; set; }
        public Guid TransportCompanyOid { get; set; }
        public DateTime BookingDate { get; set; }
        public string Description { get; set; }
    }
}