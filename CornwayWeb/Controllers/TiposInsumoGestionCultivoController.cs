using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposInsumoGestionCultivoController(ITiposInsumoGestionCultivoService tiposInsumoGestionCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTiposInsumoGestionCultivos()
        {
            IEnumerable<TiposInsumoGestionCultivo> tiposInsumoGestionCultivos = await tiposInsumoGestionCultivoService.GetTipoInsumoGestionCultivos();
            return Ok(tiposInsumoGestionCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTiposInsumoGestionCultivo(int id)
        {
            TiposInsumoGestionCultivo? tiposInsumoGestionCultivo = await tiposInsumoGestionCultivoService.GetTipoInsumoGestionCultivo(id);
            if (tiposInsumoGestionCultivo == null)
            {
                return NotFound();
            }
            return Ok(tiposInsumoGestionCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTiposInsumoGestionCultivo(
                                  [Required][MaxLength(50)] string Nombre
                                  )
        {
            var tiposInsumoGestionCultivo = await tiposInsumoGestionCultivoService.CreateTipoInsumoGestionCultivo(Nombre);
            return CreatedAtAction(nameof(GetTiposInsumoGestionCultivo), new { id = tiposInsumoGestionCultivo.IdTipoInsumoGestionCultivo }, tiposInsumoGestionCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutTiposInsumoGestionCultivo(
                                         [Required] int IdTipoInsumoGestionCultivo,
                                                                      [MaxLength(50)] string? Nombre
                                         )
        {
            var tiposInsumoGestionCultivo = await tiposInsumoGestionCultivoService.PutTipoInsumoGestionCultivo(IdTipoInsumoGestionCultivo, Nombre);
            return Ok(tiposInsumoGestionCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTiposInsumoGestionCultivo(int id)
        {
            var tiposInsumoGestionCultivo = await tiposInsumoGestionCultivoService.DeleteTipoInsumoGestionCultivo(id);
            if (tiposInsumoGestionCultivo == null)
            {
                return NotFound();
            }
            return Ok(tiposInsumoGestionCultivo);
        }
    }
    
}
