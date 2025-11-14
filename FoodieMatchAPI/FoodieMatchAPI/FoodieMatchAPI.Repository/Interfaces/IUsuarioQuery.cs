using FoodieMatchAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Interfaces
{
    public interface IUsuarioQuery
    {
        Task<IEnumerable<Usuario>> GetAll();

    }
}
