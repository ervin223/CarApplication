using CarApplication.Core.Dto;
using CarApplication.Core.Domain;

namespace CarApplication.Core.ServiceInterface
{
    public interface ICarServices
    {
        Task<Car> Create(CarDto dto);
        Task<Car> Update(CarDto dto);
        Task<Car> Delete(Guid id);
        Task<Car> GetAsync(Guid id);
    }
}
