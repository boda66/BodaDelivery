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
    public class MealControllerTest
    {
        [Test]
        public void MealController_ShouldThrowWhenMealServiceIsNull()
        {
            // Arrange
            var mockedMapper = new Mock<IMapper>();
            var mockedMealsService = new Mock<IMealService>();
            var mockedOrdersService = new Mock<IOrderService>();

            MealController controller;

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => controller = new MealController(null, mockedMapper.Object, mockedOrdersService.Object));
        }
        [Test]
        public void MealController_ShouldThrowWhenMapperServiceIsNull()
        {
            // Arrange
            var mockedMapper = new Mock<IMapper>();
            var mockedMealsService = new Mock<IMealService>();
            var mockedOrdersService = new Mock<IOrderService>();

            MealController controller;

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => controller = new MealController(mockedMealsService.Object,null, mockedOrdersService.Object));
        }
        [Test]
        public void MealController_ShouldThrowWhenOrdersServiceIsNull()
        {
            // Arrange
            var mockedMapper = new Mock<IMapper>();
            var mockedMealsService = new Mock<IMealService>();
            var mockedOrdersService = new Mock<IOrderService>();

            MealController controller;

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => controller = new MealController(mockedMealsService.Object, mockedMapper.Object, null));
        }
        [Test]
        public void Meals_ShouldRenderMealsViewModel()
        {
            // Arrange
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Meal, MealViewModel>();
                cfg.CreateMap<MealViewModel, Meal>();
            });
            var mockedMapper = new Mock<IMapper>();
            var mockedMealsService = new Mock<IMealService>();
            var mockedOrdersService = new Mock<IOrderService>();

            var controller = new MealController(mockedMealsService.Object, mockedMapper.Object, mockedOrdersService.Object);

            var meal = new Meal
            {
                Id = Guid.NewGuid()
            };
            var mealsCollection = new List<Meal>() { meal };

            mockedMealsService.Setup(c => c.GetAll()).Returns(mealsCollection.AsQueryable());

            //Act and Assert
            controller
                .WithCallTo(c => c.Meals())
                .ShouldRenderView("Meals");
        }

        [Test]
        public void PostMeals_ShouldRenderMealsViewModel()
        {
            // Arrange
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Meal, MealViewModel>();
                cfg.CreateMap<MealViewModel, Meal>();
            });
            var mockedMapper = new Mock<IMapper>();
            var mockedMealsService = new Mock<IMealService>();
            var mockedOrdersService = new Mock<IOrderService>();

            var controller = new MealController(mockedMealsService.Object, mockedMapper.Object, mockedOrdersService.Object);

            var meal = new MealViewModel
            {
            };
            
            //Act and Assert
            controller
                .WithCallTo(c => c.Meals(meal))
                .ShouldRedirectToRoute("");
        }

        [Test]
        public void AddMeal_ShouldRenderAddMealViewModel()
        {
            // Arrange
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Meal, MealViewModel>();
                cfg.CreateMap<MealViewModel, Meal>();
            });
            var mockedMapper = new Mock<IMapper>();
            var mockedMealsService = new Mock<IMealService>();
            var mockedOrdersService = new Mock<IOrderService>();

            var controller = new MealController(mockedMealsService.Object, mockedMapper.Object, mockedOrdersService.Object);

           

            //Act and Assert
            controller
                .WithCallTo(c => c.AddMeal())
                .ShouldRenderView("AddMeal");
        }

        [Test]
        public void Add_ShouldRedirectToIndexHome()
        {
            // Arrange
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Meal, MealViewModel>();
                cfg.CreateMap<MealViewModel, Meal>();
            });
            var mockedMapper = new Mock<IMapper>();
            var mockedMealsService = new Mock<IMealService>();
            var mockedOrdersService = new Mock<IOrderService>();

            var controller = new MealController(mockedMealsService.Object, mockedMapper.Object, mockedOrdersService.Object);

            var mealModel = new MealViewModel()
            {
                Title = "pesho",
                Image = "img",
                Price = 1,
                Content = "content"
            };
            var meal = new Meal();

            mockedMealsService.Setup(c => c.Add(meal));

            //Act and Assert
            controller
                .WithCallTo(c => c.Add(mealModel))
                .ShouldRedirectTo((HomeController c) => c.Index());
        }
    }
}
