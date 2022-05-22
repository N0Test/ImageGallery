using ImageGallery.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ImageGallery.Sevices
{
    public interface IImageBlobService
    {
        IList<string> GetImages();
        Task<string> Upload(string fileName, Stream file);
        Task<ImageViewModel> GetFile(string fileName);
    }
}
