using System.ComponentModel.DataAnnotations;

namespace CornwayWeb.Model
{
    public class GestionCultivo
    {
        [Key]
        public int IdGestionCultivo { get; set; }
        public required int IdCultivo { get; set; }
        public required int IdTipoGestionCultivo { get; set; }
        public required DateOnly Fecha { get; set; }
        public required string Comentario { get; set; }

        public bool Activo { get; set; }

        public virtual Cultivo? Cultivo { get; set; }
        public virtual TipoGestionCultivo? TipoGestionCultivo { get; set; }
    }
}
