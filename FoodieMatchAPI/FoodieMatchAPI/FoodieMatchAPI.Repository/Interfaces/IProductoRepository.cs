using FoodieMatchAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<Producto> CreateProduct(Producto producto);
        Task<Producto> UpdateProduct(Producto producto);
        Task<bool> DeleteProduct(int id);
    }
}
