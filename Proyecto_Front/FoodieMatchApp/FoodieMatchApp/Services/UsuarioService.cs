using FoodieMatchApp.Models;
using System.Net.Http.Json;

namespace FoodieMatchApp.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        // URL base de la API para el controlador Usuario
        private readonly string _url = "api/Usuario";

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Usuario>> GetAll()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Usuario>>(_url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Usuario> GetById(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Usuario>($"{_url}/{id}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Create(Usuario usuario) =>
            await _httpClient.PostAsJsonAsync(_url, usuario);

        public async Task Update(Usuario usuario) =>
            await _httpClient.PutAsJsonAsync($"{_url}/{usuario.UsuarioId}", usuario);

        public async Task Delete(int id) =>
            await _httpClient.DeleteAsync($"{_url}/{id}");
    }
}
