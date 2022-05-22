using ImageGallery.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImageGallery.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        //public DbSet<ImageInTagEntity> ImageTags { get; set; }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoleEntity role = new RoleEntity() { Id = 1, Name = "Admin" };

            UserEntity user = new UserEntity() { Id = 1, Email = "admin@admin.com", Name = "Admin", Password = "Admin123", RoleId = role.Id };

            ImageEntity image = new ImageEntity() { Id = 1, Name = "Palm trees", Url = "https://www.industrialempathy.com/img/remote/ZiClJf-1920w.jpg" };
            TagEntity tag1 = new TagEntity() { Id = 1, Name = "PalmTree" };
            TagEntity tag2 = new TagEntity() { Id = 2, Name = "Orange" };
            //ImageInTagEntity imageInTag = new ImageInTagEntity() { ImageId = image.Id, TagId = tag1.Id };
            //ImageInTagEntity imageInTag1 = new ImageInTagEntity() { ImageId = image.Id, TagId = tag2.Id };

            //modelBuilder.Entity<ImageInTagEntity>().HasKey("ImageId", "TagId");

            //image.Tags.Add(tag1);
            //image.Tags.Add(tag2);

            //tag1.Images.Add(image);
            //tag2.Images.Add(image);

            modelBuilder.Entity<RoleEntity>().HasData(role);
            modelBuilder.Entity<UserEntity>().HasData(user);
            modelBuilder.Entity<ImageEntity>().HasData(image);
            modelBuilder.Entity<TagEntity>().HasData(tag1, tag2);

            //modelBuilder.Entity<ImageInTagEntity>().HasData(imageInTag, imageInTag1);

        }
    }
}
