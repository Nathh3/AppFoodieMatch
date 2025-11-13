using FoodieMatchAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
