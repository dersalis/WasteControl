namespace WasteControl.Application.DTO
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Login { get; set; }    
        public string Email { get; set; }
        public string Role { get; set; }
    }
}