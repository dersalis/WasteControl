using WasteControl.Core.Enums;

namespace WasteControl.Application.DTO
{
    public class WasteExportDto : BaseDto
    {
        public string ReceivingCompanyName { get; set; }
        public string TransportCompanyName { get; set; }
        public DateTime BookingDate { get; set; }
        public string Description { get; set; }
        public WasteExportStatus Status { get; set; }
    }
}