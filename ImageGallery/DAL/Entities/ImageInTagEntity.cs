using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageGallery.DAL.Entities
{
    public class ImageInTagEntity
    {
        public int ImageId { get; set; }
        
        [ForeignKey(nameof(ImageId))]
        public ImageEntity Image { get; set; }


        public int TagId { get; set; }

        [ForeignKey(nameof(TagId))]
        public TagEntity Tag { get; set; }
    }
}