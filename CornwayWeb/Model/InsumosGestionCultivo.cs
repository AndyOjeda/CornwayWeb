using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using CornwayWeb.Models;

namespace CornwayWeb.Model
{
    public class InsumosGestionCultivo
    {
        [Key] public int IdInsumoGestionCultivo { get; set; }
        [ForeignKey(nameof(GestionesCultivo))]
        public required int IdGestionCultivo { get; set; }
        [ForeignKey(nameof(InsumoCultivo))]
        public required int IdInsumoCultivo { get; set; }
        [MaxLength(50)]
        public required string Nombre { get; set; }
        public required double Dosis { get; set; }
        [MaxLength(50)]
        public required string Unidad { get; set; }


        public virtual GestionesCultivo? GestionesCultivo { get; set; }
        public virtual InsumoCultivo? InsumoCultivo { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}
