using Dapper.Contrib.Extensions;

namespace FoodieMatchAPI.Models
{
    /// <summary>
    /// Representa la entidad de producto dentro del sistema FoodieMatch.
    /// Cada producto pertenece a un restaurante y contiene información como nombre,
    /// descripción, precio e imagen asociada.
    /// </summary>
    [Table("dbo.Producto")]
    public class Producto
    {
        /// <summary>
        /// Identificador único del producto.
        /// Es la clave primaria de la tabla <c>Producto</c>.
        /// </summary>
        [Key]
        public int ProductoId { get; set; }
        /// <summary>
        /// Identificador del restaurante al que pertenece el producto.
        /// Corresponde a una clave foránea hacia la entidad <c>Restaurante</c>.
        /// </summary>
        public int RestauranteId { get; set; }
        /// <summary>
        /// Nombre del producto ofrecido por el restaurante.
        /// Por ejemplo: "Pizza Margarita", "Sushi Roll", "Hamburguesa Clásica".
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripción detallada del producto.
        /// Puede incluir ingredientes, tamaño o características relevantes.
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Precio actual del producto expresado en formato decimal.
        /// </summary>
        public decimal Precio { get; set; }
        /// <summary>
        /// URL de la imagen asociada al producto.
        /// Permite mostrar visualmente el producto en interfaces cliente.
        /// </summary>
        public string Imagen_URL { get; set; }

    }
}
