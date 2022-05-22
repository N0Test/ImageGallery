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
    public class TagService : ICRUDService<TagModel>
    {
        private readonly ApplicationDBContext _dbContext;

        public IList<TagModel> Tags
        {
            get
            {
                return _dbContext.Tags.Select(TagMapper.Create).ToList();
            }
        }

        public TagService(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public TagModel CreateOrUpdate(TagModel item)
        {
            TagEntity entity = null;

            if (item.Id == default)
            {
                entity = TagMapper.Create(item);
                entity = _dbContext.Tags.Add(entity).Entity;
                _dbContext.SaveChanges();
                return TagMapper.Create(entity);
            }

            try
            {
                entity = _dbContext.Tags.Include(x => x.Images).FirstOrDefault(x => x.Id == item.Id);
                entity = TagMapper.Update(entity, item);
            }
            catch (Exception)
            {
                return null;
            }
            _dbContext.SaveChanges();

            return TagMapper.Create(entity);
        }

        public bool Delete(TagModel item)
        {
            var entity = _dbContext.Tags.Find(item.Id);
            entity = _dbContext.Tags.Remove(entity).Entity;
            _dbContext.SaveChanges();
            return entity != null;
        }

        public TagModel Get(int id)
        {
            return TagMapper.Create(_dbContext.Tags.Find(id));
        }

        public IList<TagModel> GetAll()
        {
            return Tags;
        }
    }

}
