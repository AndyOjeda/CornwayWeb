using System.ComponentModel.DataAnnotations;

namespace CornwayWeb.Model
{
    public class Cultivo
    {

        [Key]
        public int IdCultivo { get; set; }
        public required int IdUsuario { get; set; }
        public required int IdTipoCultivo { get; set; }
        public required string Nombre { get; set; }
        public required string Area { get; set; }

        public bool Activo { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual TipoCultivo? TipoCultivo { get; set; }

    }
}
