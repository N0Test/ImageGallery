using ImageGallery.DAL.Entities;
using ImageGallery.Models;
using System;
using System.Linq;

namespace ImageGallery.Sevices.Mapper
{
    public class ImageMapper
    {
        public static ImageModel Create(ImageEntity entity)
        {
            return new ImageModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Url = entity.Url,
                Tags = entity.Tags.Select(TagMapper.Create).ToList(),
            };
        }

        public static ImageEntity Create(ImageModel model)
        {
            return new ImageEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                Tags = model.Tags.Select(TagMapper.Create).ToList(),
            };
        }

        public static ImageEntity Update(ImageEntity entity, ImageModel model)
        {
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Url = model.Url;
            entity.Tags.Clear();
            entity.Tags = model.Tags.Select(TagMapper.Create).ToList();
            return entity;
        }
    }
}
