using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StandMngmt.Models;

namespace StandMngmt.Cores
{
    public class CarCore
    {
        private readonly HttpClient _httpClient;

        public CarCore(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task UpdateCarSellingPriceByVIMAsync(string vim, string sellingPrice)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync($"http://localhost:8080/car/{vim}/sold/{sellingPrice}", null);

                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateCarDateByVIMAsync(string vim)
        {
            try
            {
                var currentDate = DateTime.Now;
                var currentDateJson = JsonSerializer.Serialize(currentDate);
                var content = new StringContent(currentDateJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"http://localhost:8080/car/{vim}/date", content);

                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task UpdateTransactionIdByVIMAsync(string vim, int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync($"http://localhost:8080/car/{vim}/{id}", null);

                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateBuyerIdByVIMAsync(string vim, int buyerid)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync($"http://localhost:8080/car/transaction/{vim}/{buyerid}", null);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
        

