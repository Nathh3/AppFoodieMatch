using Dapper.Contrib.Extensions;

namespace FoodieMatchAPI.Models

/// <summary>
/// Representa la entidad de categoría dentro del sistema FoodieMatch.
/// Este modelo se encuentra mapeado a la tabla <c>dbo.Categoria</c> en la base de datos.
/// </summary>
/// 
{
    [Table("dbo.Categoria")]
    public class Categoria
    {
        /// <summary>
        /// Identificador único de la categoría.
        /// Es la clave primaria de la tabla <c>Categoria</c>.
        /// </summary>
        [Key]
        public int CategoriaId { get; set; }
        /// <summary>
        /// Nombre descriptivo de la categoría.
        /// Por ejemplo: "Postres", "Bebidas", "Entradas", etc.
        /// </summary>
        public string Nombre { get; set; }

    }
}
