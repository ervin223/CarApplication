using CarApplication.Core.Domain;
using CarApplication.Core.Dto;

namespace CarApplication.Core.ServiceInterface
{
    public interface ICarServices
    {
        Task<Car> DetailsAsync(Guid id);
        Task<Car> Update(CarDto dto);
        Task<Car> Delete(Guid id);
        Task<Car> Create(CarDto dto);
    }
}
