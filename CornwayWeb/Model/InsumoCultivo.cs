using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using CornwayWeb.Model;

namespace CornwayWeb.Models
{
    public class InsumoCultivo
    {
        [Key] public int IdInsumoCultivo { get; set; }

        [ForeignKey(nameof(TiposInsumoGestionCultivo))]
        public required int IdTipoInsumoGestionCultivo { get; set; }
        public required int Cantidad { get; set; }

        public virtual TiposInsumoGestionCultivo? TiposInsumoGestionCultivo { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}
