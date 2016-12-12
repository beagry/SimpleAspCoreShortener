
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleUrlShortenerSPA.Models
{
    //TODO add props requirements
    public class ShortedUrlEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, Url]
        public string Url { get; set; }
        [Required]
        public string ShortUrlSuffix { get; set; }
        public int NavigationsCount { get; set; }
        public DateTime CreateDate { get; set; }
    }
}