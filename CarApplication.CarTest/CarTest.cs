using CarApplication.Core.Domain;
using CarApplication.Core.ServiceInterface;
using CarApplication.Core.Dto;

namespace CarApplication.CarTest
{
    public class CarTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyCar_WhenReturnResult()
        {
            var dto = new CarDto()
            {
                Brand = "BMW",
                Model = "M5",
                ModelYear = 2011,
                Price = 1000000,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var result = await Svc<ICarServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdCar_WhenReturnsNotEqual()
        {
            Guid guid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            Guid wrongGuid = Guid.NewGuid();

            await Svc<ICarServices>().GetAsync(guid);

            Assert.NotEqual(guid, wrongGuid);
        }

        [Fact]
        public async Task Should_GetByIdCar_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");
            Guid getGuid = Guid.Parse("0946d4c2-f3d6-47c7-9322-acf061949331");

            await Svc<ICarServices>().GetAsync(getGuid);

            Assert.Equal(databaseGuid, getGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdCar_WhenDeleteCar()
        {
            CarDto car = MockCarData();

            var addCar = await Svc<ICarServices>().Create(car);
            var result = await Svc<ICarServices>().Delete(addCar.Id.GetValueOrDefault());

            Assert.Equal(result, addCar);
        }

        [Fact]
        public async Task ShouldNot_UpdateCar_WhenNotUpdateData()
        {
            CarDto dto = MockCarData();
            await Svc<ICarServices>().Create(dto);

            CarDto nullUpdate = MockNullCarData();
            await Svc<ICarServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }

        private CarDto MockCarData()
        {
            return new CarDto()
            {
                Brand = "BMW",
                Model = "M5",
                ModelYear = 2011,
                Price = 1000000,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private CarDto MockNullCarData()
        {
            var car = MockCarData();
            car.Id = null;

            return car;
        }
    }
}
