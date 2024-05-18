using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosechaController(ICosechaService cosechaService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCosechas()
        {
            IEnumerable<Cosecha> cosechas = await cosechaService.GetCosechas();
            return Ok(cosechas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCosecha(int id)
        {
            Cosecha? cosecha = await cosechaService.GetCosecha(id);
            if (cosecha == null)
            {
                return NotFound();
            }
            return Ok(cosecha);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCosecha(
            [FromForm][Required] int IdCultivo,
            [FromForm][Required] int Cantidad,
            [FromForm][Required] DateOnly Fecha
            )
        {
            var cosecha = await cosechaService.CreateCosecha(IdCultivo, Cantidad, Fecha);
            return CreatedAtAction(nameof(GetCosecha), new { id = cosecha.IdCosecha }, cosecha);
        }

        [HttpPut]
        public async Task<IActionResult> PutCosecha(
                       [FromForm][Required] int IdCosecha,
                                  [FromForm][Required] int? IdCultivo,
                                             [FromForm][Required] int? Cantidad,
                                                        [FromForm][Required] DateOnly? Fecha
                       )
        {
            var cosecha = await cosechaService.PutCosecha(IdCosecha, IdCultivo, Cantidad, Fecha);
            return Ok(cosecha);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCosecha(int id)
        {
            var cosecha = await cosechaService.DeleteCosecha(id);
            if (cosecha == null)
            {
                return NotFound();
            }
            return Ok(cosecha);
        }
    }
}
