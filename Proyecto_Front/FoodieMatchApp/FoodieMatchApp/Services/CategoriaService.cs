using System.Net.Http.Json;
using FoodieMatchApp.Models;

namespace FoodieMatchApp.Services
{
    public class CategoriaService
    {
        private readonly HttpClient _httpClient;
        // URL base de la API para el controlador Categoria
        private readonly string _url = "api/Categoria";

        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Categoria>> GetAll()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Categoria>>(_url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Categoria> GetById(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Categoria>($"{_url}/{id}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Create(Categoria categoria) =>
            await _httpClient.PostAsJsonAsync(_url, categoria);

        public async Task Update(Categoria categoria) =>
            await _httpClient.PutAsJsonAsync($"{_url}/{categoria.CategoriaId}", categoria);

        public async Task Delete(int id) =>
            await _httpClient.DeleteAsync($"{_url}/{id}");
    }
}