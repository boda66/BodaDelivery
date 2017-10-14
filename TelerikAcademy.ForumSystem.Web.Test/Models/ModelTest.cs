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

namespace WebApplication1.Tests.Controllers
{
    [TestFixture]
    public class ModelTest
    {
        [Test]
        public void Meal_ShouldAssignProppertiesCorrectly()
        {
            // Arrange
            Meal meal = new Meal();

            // Act
            meal.Title = "title";
            meal.Content = "content";
            meal.Image = "image";
            meal.Price = 1;

            // Assert
            Assert.AreEqual(meal.Title, "title");
            Assert.AreEqual(meal.Content, "content");
            Assert.AreEqual(meal.Image, "image");
            Assert.AreEqual(meal.Price, 1);
        }
        [Test]
        public void DataModel_ShouldAssignProppertiesCorrectly()
        {
            // Arrange
            Meal meal = new Meal();

            // Act
            meal.IsDeleted = false;
            meal.DeletedOn = new DateTime(2002,2,2);
            meal.CreatedOn = new DateTime(2003,3,3);
            meal.ModifiedOn = new DateTime(2004,4,4);

            // Assert
            Assert.AreEqual(meal.IsDeleted, false);
            Assert.AreEqual(meal.DeletedOn, new DateTime(2002, 2, 2));
            Assert.AreEqual(meal.CreatedOn, new DateTime(2003, 3, 3));
            Assert.AreEqual(meal.ModifiedOn, new DateTime(2004, 4, 4));
        }
        [Test]
        public void Applies_ShouldAssignProppertiesCorrectly()
        {
            // Arrange
            Applies apply = new Applies();

            // Act
            apply.UserName = "Pesho";
            apply.UserId = "123";

            // Assert
            Assert.AreEqual(apply.UserId, "123");
            Assert.AreEqual(apply.UserName, "Pesho");

        }

        [Test]
        public void Order_ShouldAssignProppertiesCorrectly()
        {
            // Arrange
            Order order = new Order();

            // Act
            order.Title = "title";
            order.Address = "sofia";
            order.UserName = "Pesho";

            // Assert
            Assert.AreEqual(order.Title, "title");
            Assert.AreEqual(order.UserName, "Pesho");
            Assert.AreEqual(order.Address, "sofia");
        }

        [Test]
        public void User_ShouldAssignProppertiesCorrectly()
        {
            // Arrange
            User user = new User();

            // Act
            user.IsDeleted = false;
            user.DeletedOn = new DateTime(2002, 2, 2);
            user.CreatedOn = new DateTime(2003, 3, 3);
            user.ModifiedOn = new DateTime(2004, 4, 4);

            // Assert
            Assert.AreEqual(user.IsDeleted, false);
            Assert.AreEqual(user.DeletedOn, new DateTime(2002, 2, 2));
            Assert.AreEqual(user.CreatedOn, new DateTime(2003, 3, 3));
            Assert.AreEqual(user.ModifiedOn, new DateTime(2004, 4, 4));
            Assert.IsEmpty(user.Posts);
        }
    }
}
