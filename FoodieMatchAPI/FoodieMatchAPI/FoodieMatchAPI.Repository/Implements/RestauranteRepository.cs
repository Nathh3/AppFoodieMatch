using Dapper;
using Dapper.Contrib.Extensions;
using FoodieMatchAPI.Models;
using FoodieMatchAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Implements
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly IDbConnection _db;

        public RestauranteRepository(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Restaurante> CreateRestaurant(Restaurante restaurante)
        {
            try
            {
                restaurante.RestauranteId = await _db.InsertAsync(restaurante);
                return restaurante;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el restaurante", ex);
            }
        }

        public async Task<bool> DeleteRestaurante(int id)
        {
            try
            {
                var restaurante = await _db.GetAsync<Restaurante>(id);
                if (restaurante == null)
                    throw new Exception($"No existe un restaurante con ID {id}");

                return await _db.DeleteAsync(restaurante);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el restaurante con ID {id}", ex);
            }
        }

  

        public async Task<Restaurante> UpdateRestaurant(Restaurante restaurante)
        {
            try
            {
                var actualizado = await _db.UpdateAsync(restaurante);
                if (!actualizado)
                    throw new Exception($"No se pudo actualizar el restaurante con ID {restaurante.RestauranteId}");

                return restaurante;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el restaurante con ID {restaurante.RestauranteId}", ex);
            }
        }
    }
}
