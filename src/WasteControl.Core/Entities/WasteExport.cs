using WasteControl.Core.Enums;
using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class WasteExport : BaseEntity
    {
        public ReceivingCompany? ReceivingCompany { get; private set; }
        public TransportCompany? TransportCompany { get; private set; }
        public TimeStamp BookingDate { get; private set; }
        public WasteExportDescription Description { get; private set; }
        public WasteExportStatus Status { get; private set; }
        public IEnumerable<Waste> Wastes => _wastes;

        private readonly HashSet<Waste> _wastes = new();

        public WasteExport()
        {
            Id = Guid.NewGuid();
        }

        public WasteExport(ReceivingCompany receivingCompany, TransportCompany transportCompany, TimeStamp bookingDate, 
            WasteExportDescription description, WasteExportStatus status)
        {
            Id = Guid.NewGuid();
            ReceivingCompany = receivingCompany;
            TransportCompany = transportCompany;
            BookingDate = bookingDate;
            Description = description;
            Status = status;
            IsActive = true;
        }

        public WasteExport(TimeStamp bookingDate, WasteExportDescription description, WasteExportStatus status)
        {
            Id = Guid.NewGuid();
            BookingDate = bookingDate;
            Description = description;
            Status = status;
            IsActive = true;
        }

        public void AddReceivingCompany(ReceivingCompany receivingCompany)
        {
            ReceivingCompany = receivingCompany;
        }

        public void DeleteReceivingCompany()
        {
            ReceivingCompany = null;
        }

        public void AddTransportCompany(TransportCompany transportCompany)
        {
            TransportCompany = transportCompany;
        }

        public void DeleteTransportCompany()
        {
            TransportCompany = null;
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