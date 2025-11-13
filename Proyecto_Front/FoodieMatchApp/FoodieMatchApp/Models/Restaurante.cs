namespace FoodieMatchApp.Models
{
    public class Restaurante
    {
        public int RestauranteId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public int CategoriaId { get; set; }
    }
}
