using CarApplication.Core.Domain;
using CarApplication.Core.Dto;
using CarApplication.Core.Services;

namespace CarApplication.Tests
{
    public class CarApplicationTests : TestBase
    {
        [Fact]
        public async Task Should_AddCar_WhenValidDataProvided()
        {
            // Arrange
            CarDto carDto = new()
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2022,
                Color = "Red",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            // Act
            var result = await Svc<ICarServices>().Create(carDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Toyota", result.Brand);
        }

        [Fact]
        public async Task Should_GetCarById_WhenExists()
        {
            // Arrange
            Guid carId = Guid.NewGuid();
            await Svc<ICarServices>().Create(new CarDto
            {
                Id = carId,
                Brand = "Honda",
                Model = "Civic",
                Year = 2021,
                Color = "Blue",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            });

            // Act
            var result = await Svc<ICarServices>().GetAsync(carId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(carId, result.Id);
        }

        [Fact]
        public async Task Should_DeleteCarById_WhenExists()
        {
            // Arrange
            var carDto = new CarDto
            {
                Brand = "Ford",
                Model = "Focus",
                Year = 2020,
                Color = "Green",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            var createdCar = await Svc<ICarServices>().Create(carDto);

            // Act
            var result = await Svc<ICarServicse>().Delete((Guid)createdCar.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdCar.Id, result.Id);
        }

        [Fact]
        public async Task Should_UpdateCar_WhenValidDataProvided()
        {
            // Arrange
            var carDto = new CarDto
            {
                Brand = "Mazda",
                Model = "3",
                Year = 2019,
                Color = "Black",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            var createdCar = await Svc<ICarServices>().Create(carDto);

            var updateDto = new CarDto
            {
                Id = createdCar.Id,
                Brand = "Mazda",
                Model = "3",
                Year = 2020,
                Color = "White",
                CreatedAt = createdCar.CreatedAt,
                ModifiedAt = DateTime.Now
            };

            // Act
            var result = await Svc<ICarServices>().Update(updateDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("White", result.Color);
            Assert.NotEqual(createdCar.ModifiedAt, result.ModifiedAt);
        }
    }
}
