namespace Api.Models
{
    public class UserSaveModel
    {
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }
    }
}
