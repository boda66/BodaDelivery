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
    public class OrderServiceTests
    {
       
        [Test]
        public void GetAll_ShouldReturnAllOrdersFromDatabase_WhickAreNotDeleted()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Order>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            mockedEfRepository.Setup(x => x.All);

            var service = new OrderService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            var result = service.GetAll();

            // Assert
            mockedEfRepository.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void Update_ShouldUpdateOrderInfo()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Order>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            var order = new Order();

            mockedEfRepository.Setup(x => x.Update(order));
            mockedSaveContext.Setup(x => x.Commit());

            var service = new OrderService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            service.Update(order);

            // Assert
            mockedEfRepository.Verify(x => x.Update(order), Times.Once);
            mockedSaveContext.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Delete_ShouldDeleteOrder()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Order>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            var order = new Order();

            mockedEfRepository.Setup(x => x.Delete(order));
            mockedSaveContext.Setup(x => x.Commit());

            var service = new OrderService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            service.Delete(order);

            // Assert
            mockedEfRepository.Verify(x => x.Delete(order), Times.Once);
            mockedSaveContext.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Add_ShouldAddOrder()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Order>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            var order = new Order();

            mockedEfRepository.Setup(x => x.Update(order));
            mockedSaveContext.Setup(x => x.Commit());

            var service = new OrderService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            service.Add(order);

            // Assert
            mockedEfRepository.Verify(x => x.Add(order), Times.Once);
            mockedSaveContext.Verify(x => x.Commit(), Times.Once);
        }
    }
}
