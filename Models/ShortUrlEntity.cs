
using System;

namespace SimpleUrlShortenerSPA.Models
{
    public class ShortedUrlEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}