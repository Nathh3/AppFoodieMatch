using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodieMatchAPI.Models
{
    [Table("dbo.Producto")]
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public int RestauranteId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen_URL { get; set; }
        
    }
}
