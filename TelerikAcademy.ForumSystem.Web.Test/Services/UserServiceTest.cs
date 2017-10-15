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
    public class UsersServiceTests
    {
       
        [Test]
        public void GetAll_ShouldReturnAllUsersFromDatabase_WhickAreNotDeleted()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<User>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            mockedEfRepository.Setup(x => x.All);

            var service = new UsersService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            var result = service.GetAll();

            // Assert
            mockedEfRepository.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void Update_ShouldUpdateUserInfo()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<User>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            var user = new User();

            mockedEfRepository.Setup(x => x.Update(user));
            mockedSaveContext.Setup(x => x.Commit());

            var service = new UsersService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            service.Update(user);

            // Assert
            mockedEfRepository.Verify(x => x.Update(user), Times.Once);
            mockedSaveContext.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Delete_ShouldDeleteUser()
        {
            // Arrange
            var mockedEfRepository = new Mock<IEfRepository<User>>();
            var mockedSaveContext = new Mock<ISaveContext>();

            var user = new User();

            mockedEfRepository.Setup(x => x.Delete(user));
            mockedSaveContext.Setup(x => x.Commit());

            var service = new UsersService(mockedEfRepository.Object, mockedSaveContext.Object);

            // Act
            service.Delete(user);

            // Assert
            mockedEfRepository.Verify(x => x.Delete(user), Times.Once);
            mockedSaveContext.Verify(x => x.Commit(), Times.Once);
        }
    }
}
