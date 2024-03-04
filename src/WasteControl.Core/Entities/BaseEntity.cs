using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class BaseEntity
    {
        public ID Id { get; protected set; }
        public Activity IsActive { get; protected set; }
        public TimeStamp? CreateDate { get; protected set; }
        public User? CreatedBy { get; protected set; }
        public ID? CreatedById { get; protected set; }
        public TimeStamp? ModifiedDate { get; protected set; }
        public User? ModifiedBy { get; protected set; }
        public ID? ModifiedById { get; protected set; }

        public BaseEntity(TimeStamp? createDate, User? createdBy, TimeStamp? modifiedDate, User? modifiedBy)
        {
            Id = Guid.NewGuid();
            IsActive = true;
            CreateDate = createDate;
            CreatedBy = createdBy;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
        }

        public void ChangeActivity(bool isActive)
        {
            IsActive = new Activity(isActive);
        }

        public void ChangeCreateDate(TimeStamp createDate)
        {
            CreateDate = createDate;
        }

        public void ChangeCreatedBy(User createdBy)
        {
            CreatedBy = createdBy;
        }

        public void ChangeModifiedDate(TimeStamp modifiedDate)
        {
            ModifiedDate = modifiedDate;
        }

        public void ChangeModifiedBy(User modifiedBy)
        {
            ModifiedBy = modifiedBy;
        }
    }
}