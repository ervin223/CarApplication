using Microsoft.EntityFrameworkCore;

namespace CarApplication.Data
{
    public class CarApplicationContext : DbContext
    {
        public CarApplicationContext(DbContextOptions<CarApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}

