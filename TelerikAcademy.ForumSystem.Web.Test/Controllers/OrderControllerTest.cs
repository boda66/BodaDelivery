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
    public class OrderControllerTest
    {
        [Test]
        public void Order_ShouldRedirectToMealsMeal()
        {
            // Arrange
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
            });
            var mockedMapper = new Mock<IMapper>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrderService>();

            var controller = new OrderController(mockedMapper.Object, mockedOrdersService.Object, mockedUsersService.Object);

            var user = new User
            {
                UserName = "Pesho",
                Address = "sofa"
            };
            var usersCollection = new List<User>() { user };
        
            mockedUsersService.Setup(c => c.GetAll()).Returns(usersCollection.AsQueryable());

            var order = new Order();
            mockedOrdersService.Setup(c => c.Add(order));
            //Act and Assert
            controller
                .WithCallTo(c => c.Order("Pesho", "chicken"))
                .ShouldRedirectTo((MealController c) => c.Meals());
        }

        [Test]
        public void AllOrders_ShouldRenderAllOrdersViewModel()
        {
            // Arrange
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<OrderViewModel, Order>();
            });
            var mockedMapper = new Mock<IMapper>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrderService>();

            var controller = new OrderController(mockedMapper.Object, mockedOrdersService.Object, mockedUsersService.Object);

            var order = new Order
            {
            };
            var ordersCollection = new List<Order>() { order };

            mockedOrdersService.Setup(c => c.GetAll()).Returns(ordersCollection.AsQueryable());
            
            //Act and Assert
            controller
                .WithCallTo(c => c.AllOrders())
                .ShouldRenderView("AllOrders");
        }
        [Test]
        public void TakeOrder_ShouldRedirectToIndexHome()
        {
            // Arrange
            
            var mockedMapper = new Mock<IMapper>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrderService>();

            var controller = new OrderController(mockedMapper.Object, mockedOrdersService.Object, mockedUsersService.Object);
            Guid id = Guid.NewGuid();
            var order = new Order
            {
                Id = id
            };
            var ordersCollection = new List<Order>() { order };


            mockedOrdersService.Setup(c => c.GetAll()).Returns(ordersCollection.AsQueryable());
            mockedOrdersService.Setup(c => c.Delete(order));

            //Act and Assert
            controller
                .WithCallTo(c => c.TakeOrder(id))
                .ShouldRedirectTo((HomeController c) => c.Index());
        }

        /*[Test]
        public void MyOrders_ShouldRenderMyOrdersViewModel()
        {
            // Arrange
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<OrderViewModel, Order>();
            });
            var mockedMapper = new Mock<IMapper>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedOrdersService = new Mock<IOrderService>();

            var controller = new OrderController(mockedMapper.Object, mockedOrdersService.Object, mockedUsersService.Object);

            var order = new Order
            {
            };
            var ordersCollection = new List<Order>() { order };

            mockedOrdersService.Setup(c => c.GetAll()).Returns(ordersCollection.AsQueryable());

            //Act and Assert
            controller
                .WithCallTo(c => c.MyOrders())
                .ShouldRenderView("MyOrders");
        }*/
    }
}
