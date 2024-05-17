using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace CornwayWeb.Model
{
    public class Usuarios
    {
        [Key] public int IdUsuario { get; set; }
        [ForeignKey(nameof(TipoUsuario))]
        public required int IdTipoUsuario { get; set; }
        [MaxLength(50)]
        public required string Nombres { get; set; }
        [MaxLength(50)]
        public required string Apellidos { get; set; }
        [MaxLength(50)]
        public required string Correo { get; set; }
        [MaxLength(50)]
        public required string Clave { get; set; }

        public virtual TipoUsuario? TipoUsuario { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}
