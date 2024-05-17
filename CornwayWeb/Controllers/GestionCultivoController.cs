using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionCultivoController(IGestionCultivoService gestionCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGestionCultivos()
        {
            IEnumerable<GestionCultivo> gestionCultivos = await gestionCultivoService.GetGestionCultivos();
            return Ok(gestionCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGestionCultivo(int id)
        {
            GestionCultivo? gestionCultivo = await gestionCultivoService.GetGestionCultivo(id);
            if(gestionCultivo == null) return NotFound();
            return Ok(gestionCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGestionCultivo(
            [Required] int IdCultivo,
            [Required] int IdTipoGestionCultivo,
            [Required] DateTime Fecha,
            [Required][MaxLength(40)] string Comentario
            )
        {
            var gestionCultivo = await gestionCultivoService.CreateGestionCultivo(IdCultivo, IdTipoGestionCultivo, Fecha, Comentario);
            return CreatedAtAction(nameof(GetGestionCultivo), new { id = gestionCultivo.IdGestionCultivo }, gestionCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutGestionCultivo(
            [Required] int IdGestionCultivo,
            [Required] int? IdCultivo,
            [Required] int? IdTipoGestionCultivo,
            [Required] DateTime? Fecha,
            [MaxLength(40)] string? Comentario
            )
        {
            var gestionCultivo = await gestionCultivoService.PutGestionCultivo(IdGestionCultivo, IdCultivo, IdTipoGestionCultivo, Fecha, Comentario);
            return Ok(gestionCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGestionCultivo(int id)
        {
            var gestionCultivo = await gestionCultivoService.DeleteGestionCultivo(id);
            if(gestionCultivo == null) return NotFound();
            return Ok(gestionCultivo);
        }

    }
}
