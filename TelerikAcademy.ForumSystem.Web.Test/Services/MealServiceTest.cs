using Moq;
using NUnit.Framework;
using System;
using TelerikAcademy.ForumSystem.Data.Model;
using TelerikAcademy.ForumSystem.Data.Repositories;
using TelerikAcademy.ForumSystem.Data.SaveContext;
using TelerikAcademy.ForumSystem.Services;

namespace PCstore.UnitTests.Services
{
    [TestFixture]
    public class MealServiceTests
    {
       
        [Test]
        public void GetAll_ShouldReturnAllMealsFromDatabase_WhickAreNotDeleted()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Meal>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            mockedEfRepository.Setup(x => x.All);

            var service = new MealService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            var result = service.GetAll();

            // Assert
            mockedEfRepository.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void Update_ShouldUpdateMealsInfo()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Meal>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            var meal = new Meal();

            mockedEfRepository.Setup(x => x.Update(meal));
            mockedSaveContext.Setup(x => x.Commit());

            var service = new MealService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            service.Update(meal);

            // Assert
            mockedEfRepository.Verify(x => x.Update(meal), Times.Once);
            mockedSaveContext.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Add_ShouldDeleteMeals()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Meal>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            var meal = new Meal();

            mockedEfRepository.Setup(x => x.Delete(meal));
            mockedSaveContext.Setup(x => x.Commit());

            var service = new MealService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            service.Add(meal);

            // Assert
            mockedEfRepository.Verify(x => x.Add(meal), Times.Once);
            mockedSaveContext.Verify(x => x.Commit(), Times.Once);
        }
    }
}
