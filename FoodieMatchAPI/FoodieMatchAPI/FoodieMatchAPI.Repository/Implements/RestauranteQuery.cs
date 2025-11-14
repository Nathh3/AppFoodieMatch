using Dapper;
using FoodieMatchAPI.Models;
using FoodieMatchAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Implements
{
    public class RestauranteQuery : IRestauranteQuery
    {
        private readonly IDbConnection _db;

        public RestauranteQuery(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<IEnumerable<Restaurante>> GetAll()
        {
            try
            {
                var rs = await _db.QueryAsync<Restaurante>("SELECT * FROM Restaurante");
                return rs;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
