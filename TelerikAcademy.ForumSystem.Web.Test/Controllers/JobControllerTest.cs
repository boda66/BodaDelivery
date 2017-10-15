using System;
using System.Collections.Generic;
using System.Linq;
using TelerikAcademy.ForumSystem.Web.Controllers;
using Moq;
using TelerikAcademy.ForumSystem.Services;
using AutoMapper;
using NUnit.Framework;
using TelerikAcademy.ForumSystem.Web.Models.Home;
using TelerikAcademy.ForumSystem.Data.Model;
using TestStack.FluentMVCTesting;

namespace WebApplication1.Tests.Controllers
{
    [TestFixture]
    public class JobControllerTest
    {
        [Test]
        public void Reject_ShouldRedirectToIndexHome()
        {
            // Arrange
           
            var mockedMapper = new Mock<IMapper>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedAppliesService = new Mock<IAppliesService>();

            var controller = new JobController(mockedAppliesService.Object, mockedMapper.Object, mockedUsersService.Object);
            Guid id = Guid.NewGuid();
            var apply = new Applies
            {
                Id = id
            };
            var appliesCollection = new List<Applies>() { apply };
            mockedAppliesService.Setup(c => c.GetAll()).Returns(appliesCollection.AsQueryable());
            mockedAppliesService.Setup(c => c.Delete(apply));


            //Act and Assert
            controller
                .WithCallTo(c => c.Reject(id))
                .ShouldRedirectTo((HomeController c) => c.Index());
        }
        
        [Test]
        public void AdminApplies_ShouldRenderAdminAppliesViewModel()
        {
            // Arrange
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Applies, ApplyViewModel>();
                cfg.CreateMap<ApplyViewModel, Applies>();
            });
            var mockedMapper = new Mock<IMapper>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedAppliesService = new Mock<IAppliesService>();

            var controller = new JobController(mockedAppliesService.Object, mockedMapper.Object, mockedUsersService.Object);

            var apply = new Applies
            {
                Id = Guid.NewGuid()
            };
            var appliesCollection = new List<Applies>() { apply };

            mockedAppliesService.Setup(c => c.GetAll()).Returns(appliesCollection.AsQueryable());

            //Act and Assert
            controller
                .WithCallTo(c => c.AdminApplies())
                .ShouldRenderView("AdminApplies");
        }

        [Test]
        public void ManageEmployees_ShouldRenderManageEmployeesViewModel()
        {
            // Arrange
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
            });
            var mockedMapper = new Mock<IMapper>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedAppliesService = new Mock<IAppliesService>();

            var controller = new JobController(mockedAppliesService.Object, mockedMapper.Object, mockedUsersService.Object);

            var user = new User
            {
                
            };
            var usersCollection = new List<User>() {  };

            mockedUsersService.Setup(c => c.GetAll()).Returns(usersCollection.AsQueryable());

            //Act and Assert
            controller
                .WithCallTo(c => c.ManageEmployees())
                .ShouldRenderView("ManageEmployees");
        }
    }
}
