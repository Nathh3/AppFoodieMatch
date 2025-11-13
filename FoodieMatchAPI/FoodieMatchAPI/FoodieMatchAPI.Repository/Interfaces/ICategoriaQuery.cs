using FoodieMatchAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Interfaces
{
    public interface ICategoriaQuery
    {
        Task<IEnumerable<Categoria>> GetAll();


    }
}
