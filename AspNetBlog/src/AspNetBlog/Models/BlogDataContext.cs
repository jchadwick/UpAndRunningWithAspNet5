using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetBlog.Models
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BlogDataContext()
        {
            Database.EnsureCreated();
        }

        public IQueryable<ArchivedPostsSummary> GetArchivedPosts()
        {
            return
                Posts
                    .GroupBy(x => new { x.PostedDate.Year, x.PostedDate.Month })
                    .Select(group => new ArchivedPostsSummary
                    {
                        Count = group.Count(),
                        Year = group.Key.Year,
                        Month = group.Key.Month,
                    });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ForSqlServer().UseIdentity();
        }
    }
}
