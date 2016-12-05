
using System;

namespace SimpleUrlShortenerSPA.Models
{
    //TODO add props requirements
    public class ShortedUrlEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrlSuffix { get; set; }
        public DateTime CreateDate { get; set; }
    }
}