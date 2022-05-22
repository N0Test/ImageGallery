using ImageGallery.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ImageGallery.Sevices
{
    public class ImageBlobService : IImageBlobService
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public ImageBlobService(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public async Task<string> Upload(string fileName, Stream file)
        {
            fileName = $"/images/{Guid.NewGuid()}-{fileName}";

            using (FileStream fileStream = new FileStream(_appEnvironment.WebRootPath + fileName, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public async Task<ImageViewModel> GetFile(string fileName)
        {
            byte[] bytes;

            using (FileStream fileStream = new FileStream(_appEnvironment.WebRootPath + fileName, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await fileStream.CopyToAsync(memoryStream);

                    bytes = memoryStream.ToArray();
                }

            }
            var name = Path.GetFileName(fileName);
            name = name.Substring(name.IndexOf('-') + 1);
            return new ImageViewModel()
            {
                Bytes = bytes,
                ContentType = "application/octet-stream",
                Name = name
            };
        }

        public IList<string> GetImages()
        {
            List<string> paths = new List<string>();
            DirectoryInfo info = new DirectoryInfo(_appEnvironment.WebRootPath + "/images");
            foreach (var file in info.GetFiles())
            {
                paths.Add($"/images/{file.Name}");
            }
            return paths;
        }
    }
}
