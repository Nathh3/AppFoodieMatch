namespace FoodieMatchApp.Models
{
    public class Eleccion
    {
        public int EleccionId { get; set; }
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaEleccion { get; set; }


    }
}
