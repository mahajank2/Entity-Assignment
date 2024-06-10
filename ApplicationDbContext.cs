using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAssignment
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BlogType> BlogTypes { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Monica", Email = "monica12@gmail.com", PhoneNumber = "5876542312" },
                new User { UserId = 2, UserName = "Rahul", Email = "rahul89@gmail.com", PhoneNumber = "9876665432" },
                new User { UserId = 3, UserName = "Kanika", Email = "kanika25@gmail.com", PhoneNumber = "2345678987" }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post { PostId = 1, Title = "First Post", Content = "This is the content of my first post", UserId = 1 }
            );
        }
    }
}
