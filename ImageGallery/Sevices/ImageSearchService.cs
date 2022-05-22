using ImageGallery.Models;
using System.Collections.Generic;
using System.Linq;

namespace ImageGallery.Sevices
{

    public class ImageSearchService : IImageSearchService
    {
        private readonly ICRUDService<ImageModel> _imageService;

        public ImageSearchService(ICRUDService<ImageModel> imageService)
        {
            _imageService = imageService;
        }

        public IList<ImageModel> Search(string namePart = null, int? tagId = null)
        {
            var list = _imageService.GetAll();
            if (namePart != null)
            {
                list = list
                    .Where(img => img.Name.ToLower().Contains(namePart.ToLower()))
                    .ToList();
            }
            if (tagId != null)
            {
                list = list
                    .Where(image => image.Tags.Any(tag => tag.Id == tagId))
                    .ToList();
            }
            return list;
        }
    }
}
