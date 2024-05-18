using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace CornwayWeb.Model
{
    public class GestionesCultivo
    {
        [Key] public int IdGestionCultivo { get; set; }
        [ForeignKey(nameof(Cultivos))]
        public required int IdCultivo { get; set; }
        [ForeignKey(nameof(TiposGestionCultivo))]
        public required int IdTipoGestionCultivo { get; set; }
        [ForeignKey(nameof(InsumosGestionCultivo))]
        public required int IdInsumoGestionCultivo { get; set; }
        public required DateTime FechaGestion { get; set; }
        [MaxLength(50)]
        public required string Comentario { get; set; }


        public virtual InsumosGestionCultivo? InsumosGestionCultivo { get; set; }   
        public virtual Cultivos? Cultivos { get; set; }
        public virtual TiposGestionCultivo? TiposGestionCultivo { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}
