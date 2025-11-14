using Dapper;
using FoodieMatchAPI.Models;
using FoodieMatchAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Implements
{
    public class CategoriaQuery : ICategoriaQuery
    {
        private readonly IDbConnection _db;

        public CategoriaQuery(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<IEnumerable<Categoria>> GetAll()
        {
            try
            {
                var rs = await _db.QueryAsync<Categoria>("SELECT * FROM Categoria");
                return rs;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
