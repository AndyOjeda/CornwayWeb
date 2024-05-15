using System.ComponentModel.DataAnnotations;

namespace CornwayWeb.Model
{
    public class InsumoGestionCultivo
    {
        [Key]
        public int IdInsumoGestionCultivo { get; set; }
        public required int IdGestionCultivo { get; set; }
        public required int IdTipoInsumoGestionCultivo { get; set; }
        public required string Nombre { get; set; }
        public required string Dosis { get; set; }
        public required string Unidad { get; set; }

        public bool Activo { get; set; }
        public virtual GestionCultivo? GestionCultivo { get; set; }
        public virtual TipoInsumoGestionCultivo? TipoInsumoGestionCultivo { get; set; }
    }
}
