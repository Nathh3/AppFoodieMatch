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
    public class ProductoRepository : IProductoRepository
    {
        private readonly IDbConnection _db;

        public  ProductoRepository(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<Producto> CreateProduct(Producto producto)
        {
            try
            {
                producto.ProductoId = await _db.InsertAsync(producto);
                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el producto", ex);
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var producto = await _db.GetAsync<Producto>(id);
                if (producto == null)
                    throw new Exception($"No existe un producto con ID {id}");

                return await _db.DeleteAsync(producto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el producto con ID {id}", ex);
            }
        }

        public async Task<Producto> UpdateProduct(Producto producto)
        {
            try
            {
                var actualizado = await _db.UpdateAsync(producto);
                if (!actualizado)
                    throw new Exception($"No se pudo actualizar el producto con ID {producto.ProductoId}");

                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el producto con ID {producto.ProductoId}", ex);
            }
        }
    }
}
