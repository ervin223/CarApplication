using CarApplication.Core.Domain;
using CarApplication.Core.Dto;
using CarApplication.Core.ServiceInterface;
using CarApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace CarApplication.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly CarContext _context;

        public CarServices(CarContext context)
        {
            _context = context;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();

            car.Id = Guid.NewGuid();
            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.ModelYear = dto.ModelYear;
            car.Price = dto.Price;
            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Update(CarDto dto)
        {
            var domain = new Car()
            {
                Id = dto.Id,
                Brand = dto.Brand,
                Model = dto.Model,
                ModelYear = dto.ModelYear,
                Price = dto.Price,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = DateTime.Now
            };

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
