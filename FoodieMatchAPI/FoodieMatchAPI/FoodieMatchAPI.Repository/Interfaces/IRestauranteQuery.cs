using FoodieMatchAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Interfaces
{
    public interface IRestauranteQuery
    {
        Task<IEnumerable<Restaurante>> GetAll();
    }
}
