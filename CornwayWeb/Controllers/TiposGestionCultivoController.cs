using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposGestionCultivoController(ITiposGestionCultivoService tiposGestionCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTiposGestionCultivos()
        {
            IEnumerable<TiposGestionCultivo> tiposGestionCultivos = await tiposGestionCultivoService.GetTipoGestionCultivos();
            return Ok(tiposGestionCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTiposGestionCultivo(int id)
        {
            TiposGestionCultivo? tiposGestionCultivo = await tiposGestionCultivoService.GetTipoGestionCultivo(id);
            if (tiposGestionCultivo == null)
            {
                return NotFound();
            }
            return Ok(tiposGestionCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTiposGestionCultivo(
            [FromForm][Required][MaxLength(50)] string Nombre
            )
        {
            var tiposGestionCultivo = await tiposGestionCultivoService.CreateTipoGestionCultivo(Nombre);
            return CreatedAtAction(nameof(GetTiposGestionCultivo), new { id = tiposGestionCultivo.IdTipoGestionCultivo }, tiposGestionCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutTiposGestionCultivo(
            [FromForm][Required] int IdTipoGestionCultivo,
            [FromForm][MaxLength(50)] string? Nombre
            )
        {
            var tiposGestionCultivo = await tiposGestionCultivoService.PutTipoGestionCultivo(IdTipoGestionCultivo, Nombre);
            return Ok(tiposGestionCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTiposGestionCultivo(int id)
        {
            var tiposGestionCultivo = await tiposGestionCultivoService.DeleteTipoGestionCultivo(id);
            if (tiposGestionCultivo == null)
            {
                return NotFound();
            }
            return Ok(tiposGestionCultivo);
        }
    }
    
}
