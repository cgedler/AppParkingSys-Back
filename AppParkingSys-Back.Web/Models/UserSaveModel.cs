using AppParkingSys_Back.Core.Entities;

namespace AppParkingSys_Back.Web.Models
{
    public class UserSaveModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Rol { get; set; }
    }
}
