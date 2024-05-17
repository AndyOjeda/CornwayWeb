using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace CornwayWeb.Model
{
    public class Cultivos
    {
        [Key] public int IdCultivo { get; set; }
        [ForeignKey(nameof(Usuarios))]
        public required int IdUsuario { get; set; }
        [MaxLength(50)]
        public required string Nombre { get; set; }
        [ForeignKey(nameof(TiposCultivo))]
        public required int IdTipoCultivo { get; set; }
        public required int Area { get; set; }

        public virtual Usuarios? Usuarios { get; set; }
        public virtual TiposCultivo? TiposCultivo { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}
