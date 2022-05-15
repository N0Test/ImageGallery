using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGallery.DAL.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public RoleEntity Role { get; set; }
    }
}
