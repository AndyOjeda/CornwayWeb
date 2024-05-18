using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposCultivoController(ITiposCultivoService tiposCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTiposCultivos()
        {
            IEnumerable<TiposCultivo> tiposCultivos = await tiposCultivoService.GetTiposCultivos();
            return Ok(tiposCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTiposCultivo(int id)
        {
            TiposCultivo? tiposCultivo = await tiposCultivoService.GetTiposCultivo(id);
            if (tiposCultivo == null)
            {
                return NotFound();
            }
            return Ok(tiposCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTiposCultivo(
            [FromForm][Required][MaxLength(50)] string Nombre
            )
        {
            var tiposCultivo = await tiposCultivoService.CreateTiposCultivo(Nombre);
            return CreatedAtAction(nameof(GetTiposCultivo), new { id = tiposCultivo.IdTipoCultivo }, tiposCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutTiposCultivo(
            [FromForm][Required] int IdTipoCultivo,
            [FromForm][MaxLength(50)] string? Nombre
            )
        {
            var tiposCultivo = await tiposCultivoService.PutTiposCultivo(IdTipoCultivo, Nombre);
            return Ok(tiposCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTiposCultivo(int id)
        {
            var tiposCultivo = await tiposCultivoService.DeleteTiposCultivo(id);
            if (tiposCultivo == null)
            {
                return NotFound();
            }
            return Ok(tiposCultivo);
        }
    }
    
}
