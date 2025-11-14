using Dapper;
using FoodieMatchAPI.Models;
using FoodieMatchAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Implements
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private readonly IDbConnection _db;

        public UsuarioQuery(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            try
            {
                var rs = await _db.QueryAsync<Usuario>("SELECT * FROM Usuario");
                return rs;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
