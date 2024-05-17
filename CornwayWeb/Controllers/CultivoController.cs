using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultivoController(ICultivoService cultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCultivos()
        {
            IEnumerable<Cultivo> cultivos = await cultivoService.GetCultivos();
            return Ok(cultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCultivo(int id)
        {
            Cultivo? cultivo = await cultivoService.GetCultivo(id);
            if (cultivo == null)
            {
                return NotFound();
            }
            return Ok(cultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCultivo(
            [Required] int IdUsuario,
            [Required] int IdTipoCultivo,
            [Required][MaxLength(50)] string Nombre,
            [Required][MaxLength(50)] string Area
            )
        {
            var cultivo = await cultivoService.CreateCultivo(IdUsuario, IdTipoCultivo, Nombre, Area);
            return CreatedAtAction(nameof(GetCultivo), new { id = cultivo.IdCultivo }, cultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutCultivo(
            [Required] int IdCultivo,
            [Required] int? IdUsuario,
            [Required] int? IdTipoCultivo,
            [MaxLength(50)] string? Nombre,
            [MaxLength(50)] string? Area
                       )
        {
            var cultivo = await cultivoService.PutCultivo(IdCultivo, IdUsuario, IdTipoCultivo, Nombre, Area);
            return Ok(cultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCultivo(int id)
        {
            var cultivo = await cultivoService.DeleteCultivo(id);
            if (cultivo == null)
            {
                return NotFound();
            }
            return Ok(cultivo);
        }
    }
    
}
