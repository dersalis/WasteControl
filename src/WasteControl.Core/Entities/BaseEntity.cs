using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class BaseEntity
    {
        public ID Id { get; protected set; }
        public Activity IsActive { get; protected set; }
        public TimeStamp? CreateDate { get; protected set; }
        public ID? CreatedById { get; protected set; }
        public TimeStamp? ModifiedDate { get; protected set; }
        public ID? ModifiedById { get; protected set; }

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
            CreatedById = createdBy.Id;
        }

        public void ChangeModifiedDate(TimeStamp modifiedDate)
        {
            ModifiedDate = modifiedDate;
        }

        public void ChangeModifiedBy(User modifiedBy)
        {
            ModifiedById = modifiedBy.Id;
        }
    }
}