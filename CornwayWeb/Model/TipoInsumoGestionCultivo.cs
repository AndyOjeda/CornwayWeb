using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CornwayWeb.Model
{
    public class TipoInsumoGestionCultivo
    {
        [Key]
        public int IdTipoInsumoGestionCultivo { get; set; }
        [MaxLength(50)]
        public required string Nombre { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
