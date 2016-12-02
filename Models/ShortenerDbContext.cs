using Microsoft.EntityFrameworkCore;
using System;

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

        public DbSet<ShortedUrl> ShortedUrls { get; set; }
    }

    public class ShortedUrl 
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}