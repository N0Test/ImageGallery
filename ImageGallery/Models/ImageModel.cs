using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImageGallery.Models
{
    [DisplayColumn("Name")]
    public class ImageModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        [DisplayName("Image Name")]
        public string Name { get; set; }
        public IList<TagModel> Tags { get; set; }
    }
}
