using FoodieMatchAPI.Models;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> CreateCategory(Categoria categoria);
        Task<Categoria> UpdateCategory(Categoria categoria);
        Task<bool> DeleteCategory(int id);
    }
}
