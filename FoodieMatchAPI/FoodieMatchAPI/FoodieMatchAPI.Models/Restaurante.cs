using Dapper.Contrib.Extensions;

namespace FoodieMatchAPI.Models
{
    /// <summary>
    /// Representa la entidad de restaurante dentro del sistema FoodieMatch.
    /// Cada restaurante pertenece a una categoría y contiene información
    /// de contacto, ubicación y nombre comercial.
    /// </summary>
    [Table("dbo.Restaurante")]
    public class Restaurante
    {
        /// <summary>
        /// Identificador único del restaurante.
        /// Es la clave primaria de la tabla <c>Restaurante</c>.
        /// </summary>
        [Key]
        public int RestauranteId { get; set; }
        /// <summary>
        /// Nombre del restaurante.
        /// Por ejemplo: "La Pizzería Italiana", "Sushi House", "Burger Spot".
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Número telefónico de contacto del restaurante.
        /// Puede incluir prefijo local o internacional según el formato del sistema.
        /// </summary>
        public string Telefono { get; set; }
        // <summary>
        /// Coordenada geográfica de longitud donde se ubica el restaurante.
        /// Se utiliza junto con <see cref="Latitud"/> para representar su posición en el mapa.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Coordenada geográfica de longitud donde se ubica el restaurante.
        /// Se utiliza junto con <see cref="Latitud"/> para representar su posición en el mapa.
        /// </summary>
        public decimal Longitud { get; set; }
        /// <summary>
        /// Coordenada geográfica de latitud donde se ubica el restaurante.
        /// </summary>
        public decimal Latitud { get; set; }
        /// <summary>
        /// Identificador de la categoría a la que pertenece el restaurante.
        /// Corresponde a una clave foránea hacia la entidad <c>Categoria</c>.
        /// </summary>
        public int CategoriaId { get; set; }
    }
}
