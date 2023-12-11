using CarAdvertisementService.Interfaces;
using CarAdvertisementService.Model;
using Moq;

namespace CarAdvertisementService.Test
{
    public class CarAdvertisementServiceTest
    {
        [Fact]
        public void CreatorService_EmptyRepository_Throws()
        {
            //Act + Assert
            Assert.Throws<ArgumentException>(() => new CarAdvertisementService(null));
        }

        [Fact]
        public void NonEmptyCoolection_SearchByPrice_Success()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<CarAdvertisement>>();
            var service = new CarAdvertisementService(repositoryMock.Object);
            var entities = new[]
            {
                new CarAdvertisement(50_000),
                new CarAdvertisement(150_000),
                new CarAdvertisement(250_000),

            };

            repositoryMock.Setup(repository => repository.GetEntities()).Returns(entities);

            //Act
            var results = service.FindByPrice(100_000, 150_000);

            //Assert
            Assert.Single(results);
        }

        [Fact]
        public void Save_CallsRepositorySaveMethod_Success()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<CarAdvertisement>>();
            var service = new CarAdvertisementService(repositoryMock.Object);
            bool saveCalled;

            repositoryMock.Setup(o => o.SaveEntities()).Callback(() =>
            {
                saveCalled = true;
            });

            //Act
            service.Save();

            //Assert
            repositoryMock.Verify(o => o.SaveEntities(), Times.Once);
        }
    }
}