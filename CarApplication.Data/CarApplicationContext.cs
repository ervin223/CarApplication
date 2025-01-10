using System.Collections.Generic;

public class CarApplicationContext : DbContext
{
    public CarApplicationContext(DbContextOptions<CarApplicationContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<FileToApi> FileToApis { get; set; }
}
