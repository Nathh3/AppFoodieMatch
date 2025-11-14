using FoodieMatchAPI.Models;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Interfaces
{
    public interface IEleccionRepository
    {
        Task<Eleccion> CreateEleccion(Eleccion eleccion);
        Task<Eleccion> UpdateEleccion(Eleccion eleccion);
        Task<bool> DeleteEleccion(int id);
    }
}
