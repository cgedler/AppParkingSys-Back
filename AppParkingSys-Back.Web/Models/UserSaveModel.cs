using AppParkingSys_Back.Core.Entities;

namespace AppParkingSys_Back.Web.Models
{
    public class UserSaveModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}
