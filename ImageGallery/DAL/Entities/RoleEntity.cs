using System.ComponentModel.DataAnnotations;

namespace ImageGallery.DAL.Entities
{
    public class RoleEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
