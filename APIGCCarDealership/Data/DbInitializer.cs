using System;
using System.Linq;
using APIGCCarDealership.Models;

namespace APIGCCarDealership.Data
{
    public class DbInitializer
    {
        public static void Initialize(CarContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Cars.Any())
            {
                context.Cars.Add(new Car() { Make = "Chevrolet", Model = "Corvette", Year = 2020, Color = "Red" });
                context.Cars.Add(new Car() { Make = "Ford", Model = "Mustang", Year = 2020, Color = "Black" });
                context.Cars.Add(new Car() { Make = "Chevrolet", Model = "Camaro", Year = 2020, Color = "Yellow" });
                context.Cars.Add(new Car() { Make = "Dodge", Model = "Charger", Year = 2020, Color = "Grey" });
                context.Cars.Add(new Car() { Make = "Nissan", Model = "GTR", Year = 2020, Color = "White" });
                context.SaveChanges();
            }
        }
    }
}
