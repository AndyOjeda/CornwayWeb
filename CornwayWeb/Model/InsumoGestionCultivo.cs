using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CornwayWeb.Model
{
    public class InsumoGestionCultivo
    {
        [Key]
        public int IdInsumoGestionCultivo { get; set; }

        [ForeignKey(nameof(GestionCultivo))]
        public required int IdGestionCultivo { get; set; }
        [ForeignKey(nameof(TipoInsumoGestionCultivo))]
        public required int IdTipoInsumoGestionCultivo { get; set; }
        [MaxLength(50)]
        public required string Nombre { get; set; }
        [MaxLength(50)]
        public required string Dosis { get; set; }
        [MaxLength(50)]
        public required string Unidad { get; set; }

        public virtual GestionCultivo? GestionCultivo { get; set; }
        public virtual TipoInsumoGestionCultivo? TipoInsumoGestionCultivo { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
