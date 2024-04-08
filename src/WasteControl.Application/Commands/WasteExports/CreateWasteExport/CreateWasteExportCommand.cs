using MediatR;

namespace WasteControl.Application.Commands.WasteExports.CreateWasteExport
{
    public class CreateWasteExportCommand : CommandBase, IRequest<Guid>
    {
        public Guid ReceivingCompanyOid { get; set; }
        public Guid TransportCompanyOid { get; set; }
        public DateTime BookingDate { get; set; }
        public string Description { get; set; }
    }
}