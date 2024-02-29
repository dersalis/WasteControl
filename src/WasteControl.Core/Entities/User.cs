using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class User : BaseEntity
    {
        public UserName Name { get; set; }        
        public Email Email { get; set; }

        // public User() : base(null, null, null, null)
        // {
        // }

        public User(UserName name, Email email)
            : base(null, null, null, null)
        {
            Name = name;
            Email = email;
        }
    }
}