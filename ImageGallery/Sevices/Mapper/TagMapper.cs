using ImageGallery.DAL.Entities;
using ImageGallery.Models;
using System;

namespace ImageGallery.Sevices.Mapper
{
    public class TagMapper
    {
        public static TagModel Create(TagEntity entity)
        {
            return new TagModel()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
        public static TagEntity Create(TagModel model)
        {
            return new TagEntity()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        internal static TagEntity Update(TagEntity entity, TagModel model)
        {
            entity.Name = model.Name;
            return entity;
        }
    }
}
