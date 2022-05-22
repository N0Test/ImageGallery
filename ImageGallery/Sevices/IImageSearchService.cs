using ImageGallery.Models;
using System.Collections.Generic;

namespace ImageGallery.Sevices
{
    public interface IImageSearchService
    {
        IList<ImageModel> Search(string namePart = null, int? tagId = null);
    }
}
