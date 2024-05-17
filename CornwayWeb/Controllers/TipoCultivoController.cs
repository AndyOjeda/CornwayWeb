using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;


namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCultivoController(ITipoCultivoService tipoCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTipoCultivos()
        {
            IEnumerable<TipoCultivo> tipoCultivos = await tipoCultivoService.GetTipoCultivos();
            return Ok(tipoCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoCultivo(int id)
        {
            TipoCultivo? tipoCultivo = await tipoCultivoService.GetTipoCultivo(id);
            if (tipoCultivo == null)
            {
                return NotFound();
            }
            return Ok(tipoCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipoCultivo(
            [Required][MaxLength(50)] string Nombre
            )
        {
            var tipoCultivo = await tipoCultivoService.CreateTipoCultivo(Nombre);
            return CreatedAtAction(nameof(GetTipoCultivo), new { id = tipoCultivo.IdTipoCultivo }, tipoCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutTipoCultivo(
            [Required] int IdTipoCultivo,
            [MaxLength(50)] string? Nombre
            )
        {
            var tipoCultivo = await tipoCultivoService.PutTipoCultivo(IdTipoCultivo, Nombre);
            return Ok(tipoCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTipoCultivo(int id)
        {
            var tipoCultivo = await tipoCultivoService.DeleteTipoCultivo(id);
            if (tipoCultivo == null)
            {
                return NotFound();
            }
            return Ok(tipoCultivo);
        }
    }
}
