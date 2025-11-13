using System.Net.Http.Json;
using FoodieMatchApp.Models;

namespace FoodieMatchApp.Services
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;
        // URL base de la API para el controlador Producto
        private readonly string _url = "api/Producto";

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Producto>> GetAll()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Producto>>(_url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Producto> GetById(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Producto>($"{_url}/{id}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Create(Producto producto) =>
            await _httpClient.PostAsJsonAsync(_url, producto);

        public async Task Update(Producto producto) =>
            await _httpClient.PutAsJsonAsync($"{_url}/{producto.ProductoId}", producto);

        public async Task Delete(int id) =>
            await _httpClient.DeleteAsync($"{_url}/{id}");
    }
}
