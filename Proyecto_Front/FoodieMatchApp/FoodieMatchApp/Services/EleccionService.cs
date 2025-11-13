using System.Net.Http.Json;
using System.Net.Http.Json;
using FoodieMatchApp.Models;

namespace FoodieMatchApp.Services
{
    public class EleccionService
    {
        private readonly HttpClient _httpClient;
        // URL base de la API para el controlador Eleccion
        private readonly string _url = "api/Eleccion";

        public EleccionService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Eleccion>> GetByUsuarioId(int idUsuario)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Eleccion>>($"{_url}/user/{idUsuario}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Eleccion> GetById(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Eleccion>($"{_url}/{id}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Create(Eleccion eleccion) =>
            await _httpClient.PostAsJsonAsync(_url, eleccion);

        public async Task Update(Eleccion eleccion) =>
            await _httpClient.PutAsJsonAsync($"{_url}/{eleccion.EleccionId}", eleccion);

        public async Task Delete(int id) =>
            await _httpClient.DeleteAsync($"{_url}/{id}");
    }
}
