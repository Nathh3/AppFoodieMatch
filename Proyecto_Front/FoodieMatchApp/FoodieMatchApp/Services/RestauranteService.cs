using System.Net.Http.Json;
using FoodieMatchApp.Models;

namespace FoodieMatchApp.Services
{
    public class RestauranteService
    {
        private readonly HttpClient _httpClient;
        // URL base de la API para el controlador Restaurante
        private readonly string _url = "api/Restaurante";

        public RestauranteService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Restaurante>> GetAll()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Restaurante>>(_url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Restaurante> GetById(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Restaurante>($"{_url}/{id}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Create(Restaurante restaurante) =>
            await _httpClient.PostAsJsonAsync(_url, restaurante);

        public async Task Update(Restaurante restaurante) =>
            await _httpClient.PutAsJsonAsync($"{_url}/{restaurante.RestauranteId}", restaurante);

        public async Task Delete(int id) =>
            await _httpClient.DeleteAsync($"{_url}/{id}");
    }
}
