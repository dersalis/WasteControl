using WasteControl.Core.Enums;
using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class WasteExport : BaseEntity
    {
        public ReceivingCompany? ReceivingCompany { get; private set; }
        public ID? ReceivingCompanyId { get; private set; }
        public TransportCompany? TransportCompany { get; private set; }
        public ID? TransportCompanyId { get; private set; }
        public TimeStamp BookingDate { get; private set; }
        public WasteExportDescription Description { get; private set; }
        public WasteExportStatus Status { get; private set; }
        public IEnumerable<Waste> Wastes => _wastes;

        private readonly HashSet<Waste> _wastes = new();

        public WasteExport() : base(null, null, null, null)
        {
            
        }

        public WasteExport(ReceivingCompany receivingCompany, TransportCompany transportCompany, TimeStamp bookingDate, 
            WasteExportDescription description, WasteExportStatus status)
            : base(null, null, null, null)
        {
            ReceivingCompanyId = receivingCompany.Id;
            TransportCompanyId = transportCompany.Id;
            BookingDate = bookingDate;
            Description = description;
            Status = status;
        }

        public WasteExport(TimeStamp bookingDate, WasteExportDescription description, WasteExportStatus status)
            : base(null, null, null, null)
        {
            BookingDate = bookingDate;
            Description = description;
            Status = status;
        }

        public void AddReceivingCompany(ReceivingCompany receivingCompany)
        {
            ReceivingCompanyId = receivingCompany.Id;
        }

        public void DeleteReceivingCompany()
        {
            ReceivingCompanyId = null;
        }

        public void AddTransportCompany(TransportCompany transportCompany)
        {
            TransportCompanyId = transportCompany.Id;
        }

        public void DeleteTransportCompany()
        {
            TransportCompanyId = null;
        }

        public void ChangeBookingDate(TimeStamp bookingDate)
        {
            BookingDate = bookingDate;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void ChangeStatus(WasteExportStatus status)
        {
            Status = status;
        }

        public void AddWaste(Waste waste)
        {
            _wastes.Add(waste);
        }

        public void AddWastes(IEnumerable<Waste> wastes)
        {
            _wastes.UnionWith(wastes);
        }

        public void DeleteWaste(Waste waste)
        {
            _wastes.Remove(waste);
        }

        public void ClearWastes()
        {
            _wastes.Clear();
        }
    }
}