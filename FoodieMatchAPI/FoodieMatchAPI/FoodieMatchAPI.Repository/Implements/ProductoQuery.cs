using Dapper;
using FoodieMatchAPI.Models;
using FoodieMatchAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Implements
{
    public class ProductoQuery : IProductoQuery
    {
        private readonly IDbConnection _db;

        public ProductoQuery(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<IEnumerable<Producto>> GetAll()
        {
            try
            {
                var rs = await _db.QueryAsync<Producto>("SELECT * FROM Producto");
                return rs;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
