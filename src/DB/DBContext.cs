
using BlogApi.src.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.src.DB
{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("blog");
            modelBuilder.HasPostgresEnum<Role>();
            modelBuilder.Entity<Post>().Navigation(e => e.Comments).AutoInclude();
            modelBuilder.Entity<Comment>().Navigation(e => e.User).AutoInclude();
        }}}