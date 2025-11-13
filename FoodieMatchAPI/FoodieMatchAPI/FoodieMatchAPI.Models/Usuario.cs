using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodieMatchAPI.Models
{
    [Table("dbo.Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Direccion { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
    }
}
