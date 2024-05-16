using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace CornwayWeb.Model
{
    public class Partida
    {
        [Key] public int IdPartida { get; set; }
        [ForeignKey(nameof(Cosecha))]
        public required int IdCosecha { get; set; }

        public virtual Cosecha? Cosecha { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}