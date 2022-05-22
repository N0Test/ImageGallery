using System.ComponentModel.DataAnnotations;

namespace ImageGallery.Models
{
    [DisplayColumn("Name")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleModel Role { get; set; }
    }
}
