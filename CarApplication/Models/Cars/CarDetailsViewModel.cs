
using ShopTARgv23.Models.Cars;

namespace ShopTARgv23.Models.Cars
{
    public class CarDetailsViewModel
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime BuiltDate { get; set; }
    public int CargoWeight { get; set; }
    public int Crew { get; set; }
    public int EnginePower { get; set; }

    public List<FileToApiViewModel> FileToApiViewModels { get; set; } = new List<FileToApiViewModel>();

    // only in db
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
}