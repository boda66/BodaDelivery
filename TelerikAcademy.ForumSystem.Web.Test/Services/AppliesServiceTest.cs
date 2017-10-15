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
    public class AppliesServiceTests
    {
       
        [Test]
        public void GetAll_ShouldReturnAllAppliesFromDatabase_WhickAreNotDeleted()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Applies>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            mockedEfRepository.Setup(x => x.All);

            var service = new AppliesService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            var result = service.GetAll();

            // Assert
            mockedEfRepository.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void Update_ShouldUpdateAppliesInfo()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Applies>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            var apply = new Applies();

            mockedEfRepository.Setup(x => x.Update(apply));
            mockedSaveContext.Setup(x => x.Commit());

            var service = new AppliesService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            service.Update(apply);

            // Assert
            mockedEfRepository.Verify(x => x.Update(apply), Times.Once);
            mockedSaveContext.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Delete_ShouldDeleteApplies()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Applies>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            var apply = new Applies();

            mockedEfRepository.Setup(x => x.Delete(apply));
            mockedSaveContext.Setup(x => x.Commit());

            var service = new AppliesService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            service.Delete(apply);

            // Assert
            mockedEfRepository.Verify(x => x.Delete(apply), Times.Once);
            mockedSaveContext.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Add_ShouldAddApplyInfo()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<Applies>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            var apply = new Applies();

            mockedEfRepository.Setup(x => x.Update(apply));
            mockedSaveContext.Setup(x => x.Commit());

            var service = new AppliesService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            service.Add(apply);

            // Assert
            mockedEfRepository.Verify(x => x.Add(apply), Times.Once);
            mockedSaveContext.Verify(x => x.Commit(), Times.Once);
        }
    }
}
