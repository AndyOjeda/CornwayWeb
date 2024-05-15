using System.ComponentModel.DataAnnotations;

namespace CornwayWeb.Model
{
    public class TipoCultivo
    {
        [Key]
        public int IdTipoCultivo { get; set; }
        public required string Nombre { get; set; }

        public bool Activo { get; set; }
    }
}
