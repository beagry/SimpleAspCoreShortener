using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;

using SimpleUrlShortenerSPA.Controllers;
using SimpleUrlShortenerSPA.Models;

namespace Tests
{
    public class HomeControllerTests 
    {
        HomeController controller;
        List<ShortedUrlEntity> urls = new List<ShortedUrlEntity>{
                new ShortedUrlEntity { Id = 1, Url = "http://vk.com", ShortUrlSuffix = "Hfk6d", NavigationsCount = 0, CreateDate = DateTime.Now },
                new ShortedUrlEntity { Id = 2, Url = "http://ya.ru", ShortUrlSuffix = "Hkjfds", NavigationsCount = 10, CreateDate = DateTime.Now },
                new ShortedUrlEntity { Id = 3, Url = "http://tinkoff.ru", ShortUrlSuffix = "Lsdvi", NavigationsCount = 1, CreateDate = DateTime.Now },
                new ShortedUrlEntity { Id = 4, Url = "http://mail.ru", ShortUrlSuffix = "234NJI", NavigationsCount = 11, CreateDate = DateTime.Now }
            };

        public HomeControllerTests()
        {
            var mock = new Mock<IShortUrlsRepository>();
            mock.Setup(repo=>repo.getAll()).Returns(GetUrls());
            controller = new HomeController(mock.Object);
        }

        private void SaveDb(){}

        private void SaveUrl(ShortedUrlEntity entity)
        {
            urls.Add(entity);
        }

        private List<ShortedUrlEntity> GetUrls()
        {
            return urls;
        }

        [Fact]
        public void ControllerReturnsListOfUrls()
        {
            // Act
            var result = controller.GetHistoryPage();
 
            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<ShortedUrlEntity>>(result);
            Assert.Equal(GetUrls().Count, model.Count());
        }

        [Fact]
        public void IndexPage() 
        {
            var result = controller.Index() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void ShortenUrlRequiresUrl()
        {
            var result = controller.ShortenUrl(new HomeController.UrlShorterRequest { url = "" }) as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(result.Value,HomeController.URL_ERROR_EMPTY);
        }

        [Fact]
        public void ShortenUrlRequiresHrotocol()
        {
            var result = controller.ShortenUrl(new HomeController.UrlShorterRequest { url = "fdsfds" }) as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(result.Value,HomeController.URL_ERROR_PROTOCOL_REQ);
        }

        [Fact]
        public void SaveUrl()
        {
            var url = "http://someurl.com";
            HomeController.UrlShorterRequest urlEnt = new HomeController.UrlShorterRequest { url = url };
            var entity = new ShortedUrlEntity { Id = 5, Url = url, ShortUrlSuffix = "234NJI", NavigationsCount = 11, CreateDate = DateTime.Now };
            var mock = new Mock<IShortUrlsRepository>();
            mock.Setup(repo=>repo.Create(It.IsAny<ShortedUrlEntity>()))
                .Callback((ShortedUrlEntity e) => {  
                        urls.Add(e); 
                    });
            mock.Setup(repo=>repo.Save()).Callback(() => {}).Verifiable();;

            HomeController controller = new HomeController(mock.Object);
            var result = controller.ShortenUrl(urlEnt) as JsonResult;

            Assert.NotNull(result);
            System.Console.WriteLine($"Urls count {urls.Count}");
            Assert.True(urls.Any((e) => { return e.Url == url; }));
        }

        [Fact]
        public void RandomStringGenerator() 
        {
            var s1 = HomeController.RandomString();
            var s2 = HomeController.RandomString();
            var s3 = HomeController.RandomString();


            Assert.NotEqual(s1,s2);
            Assert.NotEqual(s1,s3);
            Assert.NotEqual(s2,s3);
        }
    }
}
