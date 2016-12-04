using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SimpleUrlShortenerSPA.Models;

namespace SimpleUrlShortenerSPA.Controllers
{
    public class HomeController : Controller
    {

        #region Web Api
        
        [HttpGet("/api/history")]
        public IEnumerable<ShortedUrlEntity> GetHistoryPage(int page = 1, int itemsPerPage = 10)
        {
            return new List<ShortedUrlEntity>() {
                 new ShortedUrlEntity() { 
                    Url = "https://google.com",
                    ShortUrl = "https://ya.ru",
                    CreateDate = DateTime.Now
                 },
                 new ShortedUrlEntity() { 
                    Url = "https://google.com",
                    ShortUrl = "https://ya.ru",
                    CreateDate = DateTime.Now
                 },
              };
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
