using CarApplication.Core.Domain;
using CarApplication.Core.Dto;

namespace CarApplication.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(CarDto dto, Car car);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
    }
}
