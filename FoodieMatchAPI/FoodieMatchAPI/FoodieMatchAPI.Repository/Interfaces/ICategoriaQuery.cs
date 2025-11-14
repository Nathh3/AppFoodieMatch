using FoodieMatchAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Interfaces
{
    public interface ICategoriaQuery
    {
        Task<IEnumerable<Categoria>> GetAll();


    }
}
