using System.Collections.Generic;

namespace SimpleUrlShortenerSPA.Models 
{
    public interface IShortUrlsRepository
    {        
        IEnumerable<ShortedUrlEntity> getAll();
        ShortedUrlEntity findById(int id);
        void save(ShortedUrlEntity entity);
        void update(ShortedUrlEntity entity);
        void delete(ShortedUrlEntity entity);
        void delete(int id);
    }
}