using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodieMatchAPI.Models
{
    [Table("dbo.Eleccion")]
    public class Eleccion
    {
        [Key]
        public int EleccionId { get; set; }
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaEleccion { get; set; }


    }
}
