using AppParkingSys_Back.Core.Entities;

namespace AppParkingSys_Back.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
