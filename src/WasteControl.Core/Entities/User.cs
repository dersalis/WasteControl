using WasteControl.Core.ValueObjects;

namespace WasteControl.Core.Entities
{
    public class User : BaseEntity
    {
        public UserName Name { get; set; }
        public Login Login { get; set; }    
        public Email Email { get; set; }
        public Password Password { get; private set; }
        public Role Role { get; private set; }

        public User(UserName name, Login login, Email email, Password password)
            : base(null, null, null, null)
        {
            Name = name;
            Login = login;
            Email = email;
            Password = password;
        }
    }
}