using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SimpleUrlShortenerSPA.Models
{
    public class ShortUrlsRepository : IShortUrlsRepository
    {
        ShortenerDbContext database;
        public ShortUrlsRepository() 
        {
            database = new ShortenerDbContext();
        }

        public void Create(ShortedUrlEntity entity)
        {
            database.Add(entity);
        }
        public void Delete(int id)
        {
            ShortedUrlEntity entity = database.ShortedUrls.Find(id);
            if (entity != null)
                database.Remove(entity);
        }
        public IEnumerable<ShortedUrlEntity> getAll()
        {
            return database.ShortedUrls;
        }

        public ShortedUrlEntity GetShortedUrl(int id)
        {
            return database.ShortedUrls.Find(id);
        }
        public void Update(ShortedUrlEntity entity)
        {
            database.Entry(entity).State = EntityState.Modified;
        }
        public void Save() { database.SaveChanges(); }
    }
}