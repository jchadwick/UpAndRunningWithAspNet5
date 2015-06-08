using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetBlog.Models
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public BlogDataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = @"Server=(LocalDb)\MSSQLLocalDb;Database=AspNetBlog";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ForSqlServer().UseIdentity();
        }
    }
}
