using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImageGallery.Models
{
    [DisplayColumn("Name")]
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}