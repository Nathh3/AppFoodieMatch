namespace FoodieMatchApp.Models
{
    public class Producto
    {

        public int ProductoId { get; set; }
        public int RestauranteId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Imagen_URL { get; set; }

    }
}

