using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GCCarDealership.Models;

namespace GCCarDealership.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAll();
        Task<Car> Get(int id);
        Task Create(Car car);
        Task Edit(int id, Car car);
        Task Delete(int id);
    }
}
