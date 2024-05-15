using System.ComponentModel.DataAnnotations;

namespace CornwayWeb.Model
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string Correo { get; set; }
        public required string Clave { get; set; }

        public bool Activo { get; set; }
    }
}
