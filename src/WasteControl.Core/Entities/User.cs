using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class User : BaseEntity
    {
        public UserName Name { get; set; }        
        public Email Email { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(UserName name, Email email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            IsActive = true;
        }
    }
}