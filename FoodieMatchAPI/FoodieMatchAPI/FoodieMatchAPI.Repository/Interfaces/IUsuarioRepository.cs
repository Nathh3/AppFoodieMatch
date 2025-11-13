using FoodieMatchAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CreateUser(Usuario usuario);
        Task<Usuario> UpdateUser(Usuario usuario);
        Task<bool> DeleteUser(int id);

    }
}
