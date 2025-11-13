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
    public class EleccionRepository : IEleccionRepository
    {
        private readonly IDbConnection _db;

        public EleccionRepository(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Eleccion> CreateEleccion(Eleccion eleccion)
        {
            try
            {
                eleccion.EleccionId = await _db.InsertAsync(eleccion);
                return eleccion;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al crear la elecciom", ex);

            }
        }

        public async Task<bool> DeleteEleccion(int id)
        {
            try
            {
                var eleccion = await _db.GetAsync<Eleccion>(id);
                if (eleccion == null)
                    throw new Exception($"La eleccion con ID {id} no existe.");

                return await _db.DeleteAsync(eleccion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la eleccion", ex);
            }
        }

        public async Task<Eleccion> UpdateEleccion(Eleccion eleccion)
        {
            try
            {
                var existe = await _db.GetAsync<Eleccion>(eleccion.EleccionId);
                if (existe == null)
                    throw new Exception($"La eleccion con ID {eleccion.EleccionId} no existe.");

                await _db.UpdateAsync(eleccion);
                return eleccion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la eleccion", ex);
            }
        }
       

        
    }
}
