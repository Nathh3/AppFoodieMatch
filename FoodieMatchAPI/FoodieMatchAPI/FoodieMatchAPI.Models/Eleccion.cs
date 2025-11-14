using Dapper.Contrib.Extensions;
using System;

namespace FoodieMatchAPI.Models
{
    /// <summary>
    /// Representa la entidad de elección dentro del sistema FoodieMatch.
    /// Una elección asocia a un usuario con un producto en una fecha determinada,
    /// registrando las preferencias o selecciones realizadas por los usuarios.
    /// </summary>
    [Table("dbo.Eleccion")]
    public class Eleccion
    {
        /// <summary>
        /// Identificador único de la elección.
        /// Es la clave primaria de la tabla <c>Eleccion</c>.
        /// </summary>
        [Key]
        public int EleccionId { get; set; }
        /// <summary>
        /// Identificador del usuario que realizó la elección.
        /// Corresponde a una clave foránea hacia la entidad <c>Usuario</c>.
        /// </summary>
        public int UsuarioId { get; set; }
        /// <summary>
        /// Identificador del producto elegido por el usuario.
        /// Corresponde a una clave foránea hacia la entidad <c>Producto</c>.
        /// </summary>
        public int ProductoId { get; set; }
        /// <summary>
        /// Fecha y hora en que el usuario realizó la elección.
        /// Este campo permite registrar el momento exacto de la interacción.
        /// </summary>
        public DateTime FechaEleccion { get; set; }


    }
}
