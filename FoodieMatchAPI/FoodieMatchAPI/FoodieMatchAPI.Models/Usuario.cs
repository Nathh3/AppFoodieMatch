using Dapper.Contrib.Extensions;

namespace FoodieMatchAPI.Models
{
    /// <summary>
    /// Representa la entidad de usuario dentro del sistema FoodieMatch.
    /// Contiene la información personal, de contacto y ubicación del usuario
    /// que interactúa con la aplicación.
    /// </summary>
    [Table("dbo.Usuario")]
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario.
        /// Es la clave primaria de la tabla <c>Usuario</c>.
        /// </summary>
        [Key]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Nombre completo del usuario.
        /// Puede representar tanto a un cliente como a un administrador del sistema.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Dirección de correo electrónico asociada al usuario.
        /// Se utiliza como credencial principal para autenticación y notificaciones.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Contraseña del usuario almacenada en formato hash.
        /// Este campo nunca debe contener contraseñas en texto plano por motivos de seguridad.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Dirección física registrada por el usuario.
        /// Puede ser utilizada para envíos o localización dentro del sistema.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Coordenada geográfica de longitud asociada a la ubicación del usuario.
        /// Utilizada para cálculos de distancia o ubicación en mapas.
        /// </summary>
        public decimal Longitud { get; set; }

        /// <summary>
        /// Coordenada geográfica de latitud asociada a la ubicación del usuario.
        /// </summary>
        public decimal Latitud { get; set; }
    }
}
