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

        public HomeControllerTests()
        {
            var mock = new Mock<IShortUrlsRepository>();
            mock.Setup(repo=>repo.getAll()).Returns(GetUrls());
            controller = new HomeController(mock.Object);
        }

        [Fact]
        public void ControllerResursListOfUrls()
        {
            // Act
            var result = controller.GetHistoryPage();
 
            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<ShortedUrlEntity>>(result);
            Assert.Equal(GetUrls().Count, model.Count());
        }

        private List<ShortedUrlEntity> GetUrls()
        {
            var urls = new List<ShortedUrlEntity>
            {
                new ShortedUrlEntity { Id = 1, Url = "http://vk.com", ShortUrlSuffix = "Hfk6d", NavigationsCount = 0, CreateDate = DateTime.Now },
                new ShortedUrlEntity { Id = 1, Url = "http://ya.ru", ShortUrlSuffix = "Hkjfds", NavigationsCount = 10, CreateDate = DateTime.Now },
                new ShortedUrlEntity { Id = 1, Url = "http://tinkoff.ru", ShortUrlSuffix = "Lsdvi", NavigationsCount = 1, CreateDate = DateTime.Now },
                new ShortedUrlEntity { Id = 1, Url = "http://mail.ru", ShortUrlSuffix = "234NJI", NavigationsCount = 11, CreateDate = DateTime.Now }
            };
            return urls;
        }

        [Fact]
        public void IndexPage() 
        {
            var result = controller.Index() as ViewResult;
            Assert.NotNull(result);
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
