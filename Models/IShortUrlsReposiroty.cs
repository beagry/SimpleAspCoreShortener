using System.Collections.Generic;

namespace SimpleUrlShortenerSPA.Models 
{
    public interface IShortUrlsRepository
    {        
        IEnumerable<ShortedUrlEntity> getAll();
        ShortedUrlEntity GetShortedUrl(int id);
        void Create(ShortedUrlEntity entity);
        void Update(ShortedUrlEntity entity);
        void Delete(int id);
        void Save();
    }
}