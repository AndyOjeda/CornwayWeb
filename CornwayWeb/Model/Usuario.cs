using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CornwayWeb.Model
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [MaxLength(50)]
        public required string Nombres { get; set; }
        [MaxLength(50)]
        public required string Apellidos { get; set; }
        [MaxLength(50)]
        public required string Correo { get; set; }
        [MaxLength(50)]
        public required string Clave { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
