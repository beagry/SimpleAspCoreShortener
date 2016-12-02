using Microsoft.EntityFrameworkCore;

namespace SimpleUrlShortenerSPA.Models
{
    public class ShortenerDbContext : DbContext 
    {
        public ShortenerDbContext(){ }
        public ShortenerDbContext(DbContextOptions<ShortenerDbContext> options) 
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./TestDatabase.db");
        }

        public DbSet<ShortedUrlEntity> ShortedUrls { get; set; }
    }
}