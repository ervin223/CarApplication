using Microsoft.EntityFrameworkCore;
using CarApplication.Core.Domain;
using CarApplication.Core.Dto;
using CarApplication.Core.ServiceInterface;
using CarApplication.Data;

namespace CarApplication.ApplicationServices.Services
{
    public class CarService : ICarService
    {
        private readonly CarApplicationContext _context;

        public CarService(CarApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetDetailsAsync(Guid id)
        {
            return await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Car> CreateAsync(CarDto dto)
        {
            var car = new Car
            {
                Id = Guid.NewGuid(),
                Make = dto.Make,
                Model = dto.Model,
                Year = dto.Year,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateAsync(CarDto dto)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (car == null) return null;

            car.Make = dto.Make;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.ModifiedAt = DateTime.UtcNow;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> DeleteAsync(Guid id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null) return null;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
