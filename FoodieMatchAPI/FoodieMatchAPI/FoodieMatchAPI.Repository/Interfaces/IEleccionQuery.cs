using FoodieMatchAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Interfaces
{
    public interface IEleccionQuery
    {
        Task<IEnumerable<Eleccion>> GetAll();
        Task<IEnumerable<Eleccion>> GetByUsuarioId(int id);


    }
}
