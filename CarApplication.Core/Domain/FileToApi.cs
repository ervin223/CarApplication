namespace CarApplication.Core.Domain
{
    public class FileToApi
    {
        public Guid Id { get; set; }
        public string ExistingFilePath { get; set; }
        public Guid? CarId { get; set; } // Привязка к автомобилю
    }
}
