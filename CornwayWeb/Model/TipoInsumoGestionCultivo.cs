using System.ComponentModel.DataAnnotations;

namespace CornwayWeb.Model
{
    public class TipoInsumoGestionCultivo
    {
        [Key]
        public int IdTipoInsumoGestionCultivo { get; set; }
        public required string Nombre { get; set; }

        public bool Activo { get; set; }
    }
}
