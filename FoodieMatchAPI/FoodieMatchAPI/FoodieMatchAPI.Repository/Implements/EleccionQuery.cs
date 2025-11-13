using Dapper;
using FoodieMatchAPI.Models;
using FoodieMatchAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Repository.Implements
{
    public class EleccionQuery : IEleccionQuery
    {
        private readonly IDbConnection _db;
        public EleccionQuery(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<IEnumerable<Eleccion>> GetAll()
        {
            try
            {
                var rs = await _db.QueryAsync<Eleccion>("SELECT * FROM Eleccion");
                return rs;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Eleccion>> GetByUsuarioId(int id)
        {
            try
            {
                var sql = "SELECT * FROM Eleccion WHERE UsuarioId = @UsuarioId";
                var result = await _db.QueryAsync<Eleccion>(sql, new { UsuarioId = id });
                return result;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error al obtener las elecciones por usuario", ex);
            }
        }
    }
}
