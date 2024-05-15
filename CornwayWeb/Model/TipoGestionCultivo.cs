using System.ComponentModel.DataAnnotations;

namespace CornwayWeb.Model
{
    public class TipoGestionCultivo
    {
        [Key]
        public int IdTipoGestionCultivo { get; set; }
        public required string Nombre { get; set; }4

        public bool Activo { get; set; }
    }
}
