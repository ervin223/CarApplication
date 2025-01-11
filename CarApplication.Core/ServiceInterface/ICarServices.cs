using CarApplication.Core.Dto;

namespace CarApplication.Services
{
    public interface ICarServices
    {
        Task<IEnumerable<CarDto>> GetAllAsync();
        Task<CarDto?> GetDetailsAsync(Guid id);
        Task CreateAsync(CarDto carDto);
        Task UpdateAsync(CarDto carDto);
        Task DeleteAsync(Guid id);
    }
}
