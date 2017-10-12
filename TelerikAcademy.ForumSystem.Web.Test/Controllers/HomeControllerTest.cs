using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApplication1;
using TelerikAcademy.ForumSystem.Web;
using TelerikAcademy.ForumSystem.Web.Controllers;
using Moq;
using TelerikAcademy.ForumSystem.Services;
using AutoMapper;
using NUnit.Framework;

namespace WebApplication1.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            var mealService = new Mock<IMealService>();
            var mapper = new Mock<IMapper>();
            HomeController controller = new HomeController(mealService.Object, mapper.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About()
        {
            // Arrange
            var mealService = new Mock<IMealService>();
            var mapper = new Mock<IMapper>();
            HomeController controller = new HomeController(mealService.Object, mapper.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            var mealService = new Mock<IMealService>();
            var mapper = new Mock<IMapper>();
            HomeController controller = new HomeController(mealService.Object, mapper.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
