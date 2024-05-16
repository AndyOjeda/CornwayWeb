using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace CornwayWeb.Model
{
	public class Cosecha
	{
		[Key] public int IdCosecha { get; set; }

		[ForeignKey(nameof(Cultivo))]
		public required int IdCultivo { get; set; }
		public required int Cantidad { get; set; }
		[MaxLength(10)]
		public required string Fecha { get; set; }

		public virtual Cultivo? Cultivo { get; set; }
		[JsonIgnore]
		public bool IsActive { get; set; } = true;
	}
}