﻿using CarApplication.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}