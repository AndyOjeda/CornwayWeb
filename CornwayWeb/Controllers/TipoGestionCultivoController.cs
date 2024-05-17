using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoGestionCultivoController(ITipoGestionCultivoService tipoGestionCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTipoGestionCultivos()
        {
            IEnumerable<TipoGestionCultivo> tipoGestionCultivos = await tipoGestionCultivoService.GetTipoGestionCultivos();
            return Ok(tipoGestionCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoGestionCultivo(int id)
        {
            TipoGestionCultivo? tipoGestionCultivo = await tipoGestionCultivoService.GetTipoGestionCultivo(id);
            if (tipoGestionCultivo == null)
            {
                return NotFound();
            }
            return Ok(tipoGestionCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipoGestionCultivo(
            [Required][MaxLength(50)] string Nombre
            )
        {
            var tipoGestionCultivo = await tipoGestionCultivoService.CreateTipoGestionCultivo(Nombre);
            return CreatedAtAction(nameof(GetTipoGestionCultivo), new { id = tipoGestionCultivo.IdTipoGestionCultivo }, tipoGestionCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutTipoGestionCultivo(
            [Required] int IdTipoGestionCultivo,
            [MaxLength(50)] string? Nombre
            )
        {
            var tipoGestionCultivo = await tipoGestionCultivoService.PutTipoGestionCultivo(IdTipoGestionCultivo, Nombre);
            return Ok(tipoGestionCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTipoGestionCultivo(int id)
        {
            var tipoGestionCultivo = await tipoGestionCultivoService.DeleteTipoGestionCultivo(id);
            if (tipoGestionCultivo == null)
            {
                return NotFound();
            }
            return Ok(tipoGestionCultivo);
        }
    }

}
