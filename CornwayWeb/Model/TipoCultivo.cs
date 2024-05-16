using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CornwayWeb.Model
{
    public class TipoCultivo
    {
        [Key]
        public int IdTipoCultivo { get; set; }
        [MaxLength(50)]
        public required string Nombre { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
