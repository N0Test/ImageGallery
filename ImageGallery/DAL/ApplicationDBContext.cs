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

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoleEntity role = new RoleEntity() { Id = 1, Name = "Admin" };

            UserEntity user = new UserEntity() { Id = 1, Email = "admin@admin.com", Name = "Admin", Password = "Admin123", RoleId = role.Id };

            ImageEntity image = new ImageEntity() { Id = 1, Name = "Palm trees", Url = "/images/76fe10e5-aeb0-40d4-9e15-2ae66ba6ba3c-PalmTrees.jpg" };
            TagEntity tag1 = new TagEntity() { Id = 1, Name = "PalmTree" };
            TagEntity tag2 = new TagEntity() { Id = 2, Name = "Orange" };

            modelBuilder.Entity<RoleEntity>().HasData(role);
            modelBuilder.Entity<UserEntity>().HasData(user);
            modelBuilder.Entity<ImageEntity>().HasData(image);
            modelBuilder.Entity<TagEntity>().HasData(tag1, tag2);

            modelBuilder.Entity<ImageEntity>()
                .HasMany(img => img.Tags)
                .WithMany(tag => tag.Images).UsingEntity(a => a.HasData(new { ImagesId = image.Id, TagsId = tag1.Id }, new { ImagesId = image.Id, TagsId = tag2.Id }));

        }
    }
}
