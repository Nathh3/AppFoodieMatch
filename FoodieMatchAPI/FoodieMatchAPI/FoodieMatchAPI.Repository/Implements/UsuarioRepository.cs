using Dapper;
using Dapper.Contrib.Extensions;
using FoodieMatchAPI.Models;
using FoodieMatchAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Implements
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _db;

        public UsuarioRepository(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Usuario> CreateUser(Usuario usuario)
        {
            try
            {
                usuario.UsuarioId = await _db.InsertAsync(usuario);
                return usuario;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario", ex);
            }

        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var usuario = await _db.GetAsync<Usuario>(id);
                if (usuario == null)
                    throw new Exception($"No existe un usuario con ID {id}");

                return await _db.DeleteAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el usuario con ID {id}", ex);
            }
        }

        public async Task<Usuario> UpdateUser(Usuario usuario)
        {
            try
            {
                var actualizado = await _db.UpdateAsync(usuario);
                if (!actualizado)
                    throw new Exception($"No se pudo actualizar el usuario con ID {usuario.UsuarioId}");

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el usuario con ID {usuario.UsuarioId}", ex);
            }
        }
    }
}
