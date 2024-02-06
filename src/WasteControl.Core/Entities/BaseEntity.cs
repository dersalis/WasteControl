using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class BaseEntity
    {
        public ID Id { get; protected set; }
        public Activity IsActive { get; protected set; }
        public TimeStamp? CreateDate { get; protected set; }
        public User? CreatedBy { get; protected set; }
        public TimeStamp? ModifiedDate { get; protected set; }
        public User? ModifiedBy { get; protected set; }
    }
}