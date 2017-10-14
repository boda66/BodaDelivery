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
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Web.Models.Home;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Tests.Controllers
{
    [TestFixture]
    public class ViewModelTest
    {
        [Test]
        public void MealViewModel_ShouldAssignProppertiesCorrectly()
        {
            // Arrange
            MealViewModel meal = new MealViewModel();

            // Act
            meal.Title = "title";
            meal.Content = "content";
            meal.Image = "image";
            meal.Price = 1;
            meal.PostedOn = new DateTime(2002, 2, 2);

            // Assert
            Assert.AreEqual(meal.Title, "title");
            Assert.AreEqual(meal.Content, "content");
            Assert.AreEqual(meal.Image, "image");
            Assert.AreEqual(meal.Price, 1);
            Assert.AreEqual(meal.PostedOn, new DateTime(2002, 2, 2));
        }
        [Test]
        public void MealsViewModel_ShouldAssignProppertiesCorrectly()
        {
            // Arrange 
            MealsViewModel meal = new MealsViewModel();


            // Act
            meal.Meal = new List<MealViewModel>();
            // Assert
            Assert.IsInstanceOf<ICollection<MealViewModel>>(meal.Meal);
            
        }
        [Test]
        public void ApplyViewModel_ShouldAssignProppertiesCorrectly()
        {
            // Arrange
            ApplyViewModel apply = new ApplyViewModel();

            // Act
            apply.UserName = "Pesho";
            apply.UserId = "123";
            Guid guid = Guid.NewGuid();
            apply.id = guid;
            apply.PostedOn = new DateTime(2002, 2, 2);

            // Assert
            Assert.AreEqual(apply.UserId, "123");
            Assert.AreEqual(apply.UserName, "Pesho");
            Assert.AreEqual(apply.id, guid);
            Assert.AreEqual(apply.PostedOn, new DateTime(2002, 2, 2));
        }

        [Test]
        public void AppliesViewModel_ShouldAssignProppertiesCorrectly()
        {
            // Arrange 
            AppliesViewModel applies = new AppliesViewModel();


            // Act
            applies.Apply = new List<ApplyViewModel>();

            // Assert
            Assert.IsInstanceOf<ICollection<ApplyViewModel>>(applies.Apply);

        }
        [Test]
        public void OrderViewModel_ShouldAssignProppertiesCorrectly()
        {
            // Arrange
            OrderViewModel order = new OrderViewModel();

            // Act
            order.Title = "title";
            order.Address = "sofia";
            order.UserName = "Pesho";
            Guid guid = Guid.NewGuid();
            order.id = guid;
            order.PostedOn = new DateTime(2002, 2, 2);

            // Assert
            Assert.AreEqual(order.Title, "title");
            Assert.AreEqual(order.UserName, "Pesho");
            Assert.AreEqual(order.Address, "sofia");
            Assert.AreEqual(order.id,guid);
            Assert.AreEqual(order.PostedOn, new DateTime(2002, 2, 2));
        }
        [Test]
        public void OrdersViewModel_ShouldAssignProppertiesCorrectly()
        {
            // Arrange 
            OrdersViewModel orders = new OrdersViewModel();


            // Act
            orders.Order = new List<OrderViewModel>();

            // Assert
            Assert.IsInstanceOf<ICollection<OrderViewModel>>(orders.Order);

        }

        [Test]
        public void UserViewModel_ShouldAssignProppertiesCorrectly()
        {
            // Arrange
            UserViewModel user = new UserViewModel();

            // Act
            user.UserName = "Pesho";
            user.Id = "123";
            user.Address = "sofia";
            user.Roles = new List<IdentityUserRole>();
            user.PostedOn = new DateTime(2002, 2, 2);
             

            // Assert
            Assert.AreEqual(user.UserName, "Pesho");
            Assert.AreEqual(user.Id, "123");
            Assert.AreEqual(user.Address, "sofia");
            Assert.AreEqual(user.PostedOn, new DateTime(2002, 2, 2));
            Assert.IsInstanceOf<ICollection<IdentityUserRole>>(user.Roles);
        }

        [Test]
        public void UsersViewModel_ShouldAssignProppertiesCorrectly()
        {
            // Arrange 
            UsersViewModel users = new UsersViewModel();


            // Act
            users.Users = new List<UserViewModel>();

            // Assert
            Assert.IsInstanceOf<ICollection<UserViewModel>>(users.Users);

        }
        [Test]
        public void HomeViewModel_ShouldAssignProppertiesCorrectly()
        {
            // Arrange 
            HomeViewModel home = new HomeViewModel();


            // Act
            home.Meal = new List<MealViewModel>();

            // Assert
            Assert.IsInstanceOf<ICollection<MealViewModel>>(home.Meal);

        }
    }
}
