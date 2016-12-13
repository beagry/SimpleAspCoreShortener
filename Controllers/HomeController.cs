using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

using SimpleUrlShortenerSPA.Models;

namespace SimpleUrlShortenerSPA.Controllers
{
    //BUG: angular app crash after return from outer link 
    public class HomeController : Controller, IDisposable
    {
        public static readonly string URL_ERROR_PROTOCOL_REQ = "Url должен начинаться с 'http://' или 'https://'";
        public static readonly string URL_ERROR_EMPTY = "Url не может быть пустым";


        static List<string> masks = new List<string> { "http://", "https://" };
        private IShortUrlsRepository repo;

        public HomeController(IShortUrlsRepository repository)
        {
            repo = repository;
        }

        #region Web Api
        public class UrlShorterRequest
        {
            public string url { get; set; }
        }

        [HttpPost("/api/shorten")]
        public IActionResult ShortenUrl([FromBody]UrlShorterRequest request)
        {
            if (request.url == null || request.url == string.Empty) 
                return new BadRequestObjectResult(URL_ERROR_EMPTY);
            
            //TODO: check URL with regexp /http(s)?://[A-Za-z0-9\.]+\.[A-Za-z0-9]+.*/
            if (!masks.Any(s => request.url.StartsWith(s, StringComparison.OrdinalIgnoreCase)))
                return new BadRequestObjectResult(URL_ERROR_PROTOCOL_REQ);
            
            var randString = "";
            do {
                randString = RandomString();
            } while(repo.getAll().Any(s => s.ShortUrlSuffix.Equals(s)));

            ShortedUrlEntity shortenUrl = new ShortedUrlEntity() {
                Url = request.url,
                ShortUrlSuffix = randString,
                CreateDate = DateTime.Now
            };
            try {
                repo.Create(shortenUrl);
                repo.Save();
            }
            catch(Exception)
            {
                return new StatusCodeResult(500);
            }
            System.Console.WriteLine($">>>Tiny Url successfuly created { request.url }");
            return Json(shortenUrl);
        }

        [HttpGet("/api/history")]
        public IEnumerable<ShortedUrlEntity> GetHistoryPage(int page = 1, int itemsPerPage = 10)
        {
            System.Console.WriteLine(">>>Return history");
            return repo.getAll();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)] 
        public async Task<IActionResult> GetUrl(string url)
        {
            if (url == null || url == string.Empty)
                return new RedirectToActionResult("Index","Home",null);
            
            var item = repo.getAll().FirstOrDefault(r => r.ShortUrlSuffix.Equals(url));
            if ( item != null)  
            {
                await Task.Run(() => {
                        item.NavigationsCount++;
                        try
                        {
                            repo.Update(item);
                            repo.Save();
                        }
                        catch(Exception e)
                        {
                            System.Console.WriteLine($"HomeController.GetUrl() exception: {e.ToString()}");
                        }
                    });
                return new RedirectResult(item.Url, true);
            } 
            else 
                return new RedirectToActionResult("Index","Home",null);
        }

        private static Random random = new Random();
        public static string RandomString(int length = 6)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
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
