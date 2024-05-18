using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace CornwayWeb.Model
{
    public class Auth
    {
        [MaxLength(50)]
        public required string Correo { get; set; }
        [MaxLength(50)]
        public required string Clave { get; set; }
    }
}
