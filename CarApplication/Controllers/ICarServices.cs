

namespace CarApplication.Controllers
{
    internal interface ICarServices
    {
        Task CreateAsync(CarDto carDto);
        Task DeleteAsync(Guid id);
        Task<string?> GetAllAsync();
        Task<string?> GetDetailsAsync(Guid id);
        Task UpdateAsync(CarDto carDto);
    }
}