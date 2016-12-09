using Microsoft.EntityFrameworkCore;

namespace SimpleUrlShortenerSPA.Models
{
    public class ShortenerDbContext : DbContext 
    {
        private static bool created = false;
        public ShortenerDbContext()
        {
            if (!created)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
                created = true;
            }
         }
        public ShortenerDbContext(DbContextOptions<ShortenerDbContext> options) 
        : base(options)
        {
            if (!created)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
                created = true;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./TestDatabase.db");
        }

        public DbSet<ShortedUrlEntity> ShortedUrls { get; set; }
    }
}