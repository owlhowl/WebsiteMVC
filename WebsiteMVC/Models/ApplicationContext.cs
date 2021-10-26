using Microsoft.EntityFrameworkCore;
using System;

namespace WebsiteMVC.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().HasData(new BlogPost[]
            {
                new BlogPost { Id = 1, Title = "Заголовок статьи 1", Content = "Содержание статьи 1", Date = DateTime.Now},
                new BlogPost { Id = 2, Title = "Заголовок статьи 2", Content = "Содержание статьи 2", Date = DateTime.Now},
                new BlogPost { Id = 3, Title = "Заголовок статьи 3", Content = "Содержание статьи 3", Date = DateTime.Now},
            });

            Role admin = new Role() { Id = 1, Name = "admin" };
            Role user = new Role() { Id = 2, Name = "user" };

            modelBuilder.Entity<Role>().HasData(admin, user);
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "admin", Password = "admin", RoleId = admin.Id});

            base.OnModelCreating(modelBuilder);
        }
    }
}
