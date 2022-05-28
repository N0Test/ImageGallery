using ImageGallery.DAL.Entities;
using ImageGallery.Models;
using System;

namespace ImageGallery.Sevices.Mapper
{
    public static class UserMapper
    {
        public static UserModel Create(UserEntity entity)
        {

            return new UserModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Name = entity.Name,
                Password = entity.Password,
                Role = RoleMapper.Create(entity.Role),
            };
        }
        public static UserEntity Create(UserModel model)
        {

            return new UserEntity
            {
                Id = model.Id,
                Email = model.Email,
                Name = model.Name,
                Password = model.Password,
                RoleId = model.Role.Id,
            };
        }

        public static UserEntity Update(UserEntity entity, UserModel model)
        {
            entity.Email = model.Email;
            entity.Name = model.Name;
            entity.Password = model.Password;
            entity.Role = RoleMapper.Create(model.Role);
            return entity;
        }
    }
    public static class RoleMapper
    {
        public static RoleModel Create(RoleEntity entity)
        {
            return new RoleModel()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
        public static RoleEntity Create(RoleModel model)
        {
            return new RoleEntity()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
