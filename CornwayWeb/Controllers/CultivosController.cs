using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultivosController(ICultivosService cultivosService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCultivos()
        {
            IEnumerable<Cultivos> cultivos = await cultivosService.GetCultivos();
            return Ok(cultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCultivo(int id)
        {
            Cultivos? cultivo = await cultivosService.GetCultivo(id);
            if (cultivo == null)
            {
                return NotFound();
            }
            return Ok(cultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCultivo(
            [Required] int IdUsuario,
            [Required][MaxLength(50)] string Nombre,
            [Required] int IdTipoCultivo,
            [Required] int Area

                                 )
        {
            var cultivo = await cultivosService.CreateCultivo(IdUsuario, Nombre, IdTipoCultivo, Area);
            return CreatedAtAction(nameof(GetCultivo), new { id = cultivo.IdCultivo }, cultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutCultivo(
            [Required] int IdCultivo,
            [Required] int IdUsuario,
            [MaxLength(50)] string? Nombre,
            [Required] int IdTipoCultivo,
            [Required] int Area
                                      )
        {
            var cultivo = await cultivosService.PutCultivo(IdCultivo, IdUsuario, Nombre, IdTipoCultivo, Area);
            return Ok(cultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCultivo(int id)
        {
            var cultivo = await cultivosService.DeleteCultivo(id);
            if (cultivo == null)
            {
                return NotFound();
            }
            return Ok(cultivo);
        }
    }
    
}
