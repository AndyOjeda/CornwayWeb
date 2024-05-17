using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CornwayWeb.Model
{
    public class Cultivo
    {

        [Key]
        public int IdCultivo { get; set; }

        [ForeignKey(nameof(Usuario))]
        public required int IdUsuario { get; set; }

        [ForeignKey(nameof(TipoCultivo))]
        public required int IdTipoCultivo { get; set; }

        public required string Nombre { get; set; }

        public required string Area { get; set; }
        

        public virtual Usuario? Usuario { get; set; }
        public virtual TipoCultivo? TipoCultivo { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }

    }
}
