using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GCCarDealership.Models;
using Microsoft.AspNetCore.Mvc;

namespace GCCarDealership.Services
{
    public class ApiCarService : ICarService
    {
        private readonly HttpClient _client;

        public ApiCarService(HttpClient client)
        {
            _client = client;
        }

        public async Task Create(Car car)
        {
            //Create car in database
            //Post from database to API. aka refresh API
            await _client.PostAsJsonAsync("Cars", car);
        }

        public async Task<Car> Get(int id)
        {
            return await _client.GetFromJsonAsync<Car>($"Cars/{id}");
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<Car>>("Cars");
        }

        public async Task Edit(int id, Car car)
        {
            await _client.PutAsJsonAsync<Car>($"Cars/{id}", car);
        }

        public async Task Delete(int id)
        {
            await _client.DeleteAsync($"Cars/{id}");
        }
    }
}
