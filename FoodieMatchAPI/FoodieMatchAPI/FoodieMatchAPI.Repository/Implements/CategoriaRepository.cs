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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IDbConnection _db;

        public CategoriaRepository(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<Categoria> CreateCategory(Categoria categoria)
        {
            try
            {
                categoria.CategoriaId = await _db.InsertAsync(categoria);
                return categoria;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al crear la categoría", ex);

            }

        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                var categoria = await _db.GetAsync<Categoria>(id);
                if (categoria == null)
                    throw new Exception($"La categoría con ID {id} no existe.");

                return await _db.DeleteAsync(categoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la categoría", ex);
            }
        }

        public async Task<Categoria> UpdateCategory(Categoria categoria)
        {
            try
            {
                var existe = await _db.GetAsync<Categoria>(categoria.CategoriaId);
                if (existe == null)
                    throw new Exception($"La categoría con ID {categoria.CategoriaId} no existe.");

                await _db.UpdateAsync(categoria);
                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la categoría", ex);
            }
        }
    }
}
