using ImageGallery.DAL;
using ImageGallery.DAL.Entities;
using ImageGallery.Models;
using ImageGallery.Sevices.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageGallery.Sevices
{
    public class ImageService : ICRUDService<ImageModel>
    {
        private readonly ApplicationDBContext _dbContext;

        public IList<ImageModel> Images 
        {
            get => _dbContext.Images.Include(x => x.Tags)
                .Select(ImageMapper.Create)
                .ToList();
        }

        public ImageService(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public ImageModel CreateOrUpdate(ImageModel item)
        {
            ImageEntity entity = null;

            if (item.Id == default)
            {
                entity = ImageMapper.Create(item);
                entity = _dbContext.Images.Add(entity).Entity;
                _dbContext.SaveChanges();
                return ImageMapper.Create(entity);
            }

            try
            {
                entity = _dbContext.Images.Include(x => x.Tags).FirstOrDefault(x => x.Id == item.Id);
                entity = ImageMapper.Update(entity, item);
                var tags = _dbContext.Tags.Where(x => entity.Tags.Contains(x));
                entity.Tags = tags.ToList();
            }
            catch (Exception)
            {
                return null;
            }
            _dbContext.SaveChanges();

            return ImageMapper.Create(entity);
        }

        public bool Delete(ImageModel item)
        {
            var entity = _dbContext.Images.Find(item.Id);
            entity = _dbContext.Images.Remove(entity).Entity;
            _dbContext.SaveChanges();
            return entity != null;
        }

        public ImageModel Get(int id)
        {
            return Images.FirstOrDefault(x => x.Id == id);
        }

        public IList<ImageModel> GetAll()
        {
            return Images;
        }
    }
}