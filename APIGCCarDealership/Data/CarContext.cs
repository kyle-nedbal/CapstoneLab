using System;
using APIGCCarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace APIGCCarDealership.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
