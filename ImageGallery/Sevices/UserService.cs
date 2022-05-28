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

    public class UserService : ICRUDService<UserModel>
    {
        private readonly ApplicationDBContext _dbContext;

        public IList<UserModel> Users
        {
            get
            {
                return _dbContext.Users
                    .Include(x => x.Role)
                    .Select(UserMapper.Create).ToList();
            }
        }

        public UserService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public UserModel CreateOrUpdate(UserModel item)
        {
            UserEntity entity = null;

            if(item.Id == default)
            {
                item.Role = RoleMapper.Create(_dbContext.Roles.Find(1));
                entity = UserMapper.Create(item);
                entity = _dbContext.Users.Add(entity).Entity;
                _dbContext.SaveChanges();
                return UserMapper.Create(entity);
            }

            try
            {
                entity = _dbContext.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == item.Id);
                entity = UserMapper.Update(entity, item);
            }
            catch(Exception)
            {
                return null;
            }
            _dbContext.SaveChanges();

            return UserMapper.Create(entity);
        }

        public bool Delete(UserModel item)
        {
            throw new NotImplementedException();
        }

        public UserModel Get(int id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
        }

        public IList<UserModel> GetAll()
        {
            return Users;
        }
    }
}
