
using BlogApi.src.DB.Config;
using BlogApi.src.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.src.DB
{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public DbSet<Category> Category { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("blog");
            modelBuilder.Entity<Category>().HasData(new List<Category>
            {
                new(){
                    Id = 1,
                    Name = "Angular"
                },
                                new(){
                    Id = 2,
                    Name = "Laravel"
                }

            });
            modelBuilder.Entity<Post>().HasData(new List<Post>
            {
                new() {
                    Id = 1,
                    Name = "Introduction to ASP.NET Core",
                    Content = "ASP.NET Core is a free and open-source web framework developed by Microsoft.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTB8vWxHzX5mIpJz5aVrqHrDRRfvrb69esckGkGlm6HPw&s",
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    UpdatedAt = DateTime.UtcNow.AddDays(-1),
                    CategoryId = 1
                },
                new() {
                    Id = 2,
                    Name = "Getting Started with Entity Framework Core",
                    Content = "Entity Framework Core is a lightweight, extensible, and cross-platform version of the popular Entity Framework data access technology.",
                    ImageUrl = "https://media.licdn.com/dms/image/D4D12AQEKTlrp8y_g0A/article-cover_image-shrink_720_1280/0/1683976532326?e=2147483647&v=beta&t=41WsN7UYuouE7WcA_pmij4yF__uReRR5qm8rdtngHOM",
                    CreatedAt = DateTime.UtcNow.AddDays(-8),
                    UpdatedAt = DateTime.UtcNow.AddDays(-2),
                    CategoryId = 1
                },
                new() {
                    Id = 3,
                    Name = "Understanding Middleware in ASP.NET Core",
                    Content = "Middleware is software that's assembled into an application pipeline to handle requests and responses.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSv3lYL2b29XYVOoFeRIBDWQ9Sb9NL7MS1eBeApMQ8GOw&s",
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    UpdatedAt = DateTime.UtcNow.AddDays(-3),
                    CategoryId = 1

                },
                new() {
                    Id = 4,
                    Name = "Exploring Razor Pages in ASP.NET Core",
                    Content = "Razor Pages is a page-based programming model that makes building web UI easier and more productive.",
                    ImageUrl = "https://www.examturf.com/eqtkhtabd/wp-content/uploads/2021/02/ASP.NET-Framework.jpg",
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    UpdatedAt = DateTime.UtcNow.AddDays(-1),
                    CategoryId = 1
                },
                new() {
                    Id = 5,
                    Name = "Introduction to Blazor",
                    Content = "Blazor is a framework for building interactive web applications with .NET and C#.",
                    ImageUrl = "https://positiwise.com/blog/wp-content/uploads/2023/01/common-architectures-in-asp-.net-core.jpg",
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    UpdatedAt = DateTime.UtcNow,
                    CategoryId = 1
                }

    });

            modelBuilder.Entity<Comment>()
            .HasOne(n => n.Post)
            .WithMany(n => n.Comments)
            .HasForeignKey(n => n.PostId);
            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                Id = 1,
                Content = "This is a sample comment.",
                CreatedAt = DateTime.UtcNow,
                PostId = 3
            });
            modelBuilder.Entity<RolePrivilege>()
            .HasOne(n => n.Role)
            .WithMany(n => n.RolePrivileges)
            .HasForeignKey(n => n.RoleId)
            .HasConstraintName("FK_RolePrivilege_Roles");
            modelBuilder.ApplyConfiguration(new UserRoleMappingConfig());}
    }
}