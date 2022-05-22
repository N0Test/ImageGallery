using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImageGallery.Models
{
    [DisplayColumn("Name")]
    public class TagModel
    {
        public int Id { get; set; }
        [DisplayName("Tag Name")]
        public string Name { get; set; }
    }
}
