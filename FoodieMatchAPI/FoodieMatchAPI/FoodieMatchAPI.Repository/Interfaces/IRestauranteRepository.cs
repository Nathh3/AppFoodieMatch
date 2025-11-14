using FoodieMatchAPI.Models;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Interfaces
{
    public interface IRestauranteRepository
    {
        Task<Restaurante> CreateRestaurant(Restaurante restaurante);
        Task<Restaurante> UpdateRestaurant(Restaurante restaurante);
        Task<bool> DeleteRestaurante(int id);
    }
}
