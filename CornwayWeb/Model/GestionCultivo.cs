
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace CornwayWeb.Model
{
    public class GestionCultivo
    {
        [Key]
        public int IdGestionCultivo { get; set; }
        [ForeignKey(nameof(Cultivo))]
        public required int IdCultivo { get; set; }
        [ForeignKey(nameof(TipoGestionCultivo))]
        public required int IdTipoGestionCultivo { get; set; }
        public required DateOnly Fecha { get; set; }
        public required string Comentario { get; set; }

        public virtual Cultivo? Cultivo { get; set; }
        public virtual TipoGestionCultivo? TipoGestionCultivo { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
