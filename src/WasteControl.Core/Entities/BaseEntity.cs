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

        public BaseEntity(TimeStamp? createDate, ID? createdById, TimeStamp? modifiedDate, ID? modifiedById)
        {
            Id = Guid.NewGuid();
            IsActive = true;
            CreateDate = createDate;
            CreatedById = createdById;
            ModifiedDate = modifiedDate;
            ModifiedById = modifiedById;
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