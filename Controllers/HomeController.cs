using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using SimpleUrlShortenerSPA.Models;

namespace SimpleUrlShortenerSPA.Controllers
{
    public class HomeController : Controller
    {

        static List<ShortedUrlEntity> history = new List<ShortedUrlEntity>() {
            new ShortedUrlEntity() { 
            Url = "https://nope.com",
            ShortUrl = "https://ya.ru",
            CreateDate = DateTime.Now
            },
            new ShortedUrlEntity() { 
            Url = "https://google.com",
            ShortUrl = "https://ya.ru",
            CreateDate = DateTime.Now
            },
        };

        #region Web Api

        public class UrlShorterRequest
        {
            public string url { get; set; }
        }

        [HttpPost("/api/shorten")]
        public IActionResult ShortenUrl([FromBody]UrlShorterRequest request)
        {
            // if (url == null || url == string.Empty)

            ShortedUrlEntity shortenUrl = new ShortedUrlEntity() {
                Url = request.url,
                ShortUrl = "https://ya.ru",
                CreateDate = DateTime.Now
            };
            history.Add(shortenUrl);
            System.Console.WriteLine($">>>Url successfuly shorted { request.url }");
            return Json(shortenUrl);
        }

        [HttpGet("/api/history")]
        public IEnumerable<ShortedUrlEntity> GetHistoryPage(int page = 1, int itemsPerPage = 10)
        {
            System.Console.WriteLine(">>>Return history");
            return history;
        }

        #endregion //end Web Api

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
