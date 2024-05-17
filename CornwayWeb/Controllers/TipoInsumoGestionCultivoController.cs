using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TipoInsumoGestionCultivoController(ITipoInsumoGestionCultivoService tipoInsumoGestionCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTipoInsumoGestionCultivos()
        {
            IEnumerable<TipoInsumoGestionCultivo> tipoInsumoGestionCultivos = await tipoInsumoGestionCultivoService.GetTipoInsumoGestionCultivos();
            return Ok(tipoInsumoGestionCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoInsumoGestionCultivo(int id)
        {
            TipoInsumoGestionCultivo? tipoInsumoGestionCultivo = await tipoInsumoGestionCultivoService.GetTipoInsumoGestionCultivo(id);
            if (tipoInsumoGestionCultivo == null)
            {
                return NotFound();
            }
            return Ok(tipoInsumoGestionCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipoInsumoGestionCultivo(
                       [Required][MaxLength(50)] string Nombre
                       )
        {
            var tipoInsumoGestionCultivo = await tipoInsumoGestionCultivoService.CreateTipoInsumoGestionCultivo(Nombre);
            return CreatedAtAction(nameof(GetTipoInsumoGestionCultivo), new { id = tipoInsumoGestionCultivo.IdTipoInsumoGestionCultivo }, tipoInsumoGestionCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutTipoInsumoGestionCultivo(
                       [Required] int IdTipoInsumoGestionCultivo,
                                  [MaxLength(50)] string? Nombre
                       )
        {
            var tipoInsumoGestionCultivo = await tipoInsumoGestionCultivoService.PutTipoInsumoGestionCultivo(IdTipoInsumoGestionCultivo, Nombre);
            return Ok(tipoInsumoGestionCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTipoInsumoGestionCultivo(int id)
        {
            var tipoInsumoGestionCultivo = await tipoInsumoGestionCultivoService.DeleteTipoInsumoGestionCultivo(id);
            if (tipoInsumoGestionCultivo == null)
            {
                return NotFound();
            }
            return Ok(tipoInsumoGestionCultivo);
        }
    }
}
