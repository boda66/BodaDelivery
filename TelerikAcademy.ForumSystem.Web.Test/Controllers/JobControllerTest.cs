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
using AutoMapper.QueryableExtensions;
using TelerikAcademy.ForumSystem.Web.Models.Home;
using System.Reflection;
using TelerikAcademy.ForumSystem.Data.Model;

namespace WebApplication1.Tests.Controllers
{
    [TestFixture]
    public class JobControllerTest
    {
        [Test]
        public void AdminApplies_ShouldReturnActionResultWithAppliesViewModel()
        {
           /*  Arrange
            var appliesService = new Mock<IAppliesService>();
            var usersService = new Mock<IUsersService>();
            var mapper = new Mock<IMapper>();
            Guid guid = Guid.NewGuid();
            List<Applies> queryResult = new List<Applies>()
            {
                new Applies
                {
                    Id = guid,
                },
            };
            

            appliesService.SetupGet(x => x.GetAll()).Returns(() => queryResult.Select(x => new Applies() { Id = guid }).AsQueryable());
           // appliesService.SetupGet(x => x.GetAll().ProjectTo<AppliesViewModel>()).Returns(() => queryResult.Select(x => new AppliesViewModel() { Apply = new List<ApplyViewModel>() }).AsQueryable());
           // appliesService.SetupGet(x => x.GetAll().ProjectTo<AppliesViewModel>().ToList()).Returns(() => queryResult.Select(x => new AppliesViewModel() { Apply = new List<ApplyViewModel>() }).ToList());
            var controller = new JobController(appliesService.Object, mapper.Object, usersService.Object);

            // Act
            ViewResult result = controller.AdminApplies() as ViewResult;

            // Assert 
            Assert.IsNotNull(result);*/
        }
        
        
    }
}
