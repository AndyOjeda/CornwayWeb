using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoGestionCultivoController(IInsumoGestionCultivoService insumoGestionCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetInsumoGestionCultivos()
        {
            IEnumerable<InsumoGestionCultivo> insumoGestionCultivos = await insumoGestionCultivoService.GetInsumoGestionCultivos();
            return Ok(insumoGestionCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsumoGestionCultivo(int id)
        {
            InsumoGestionCultivo? insumoGestionCultivo = await insumoGestionCultivoService.GetInsumoGestionCultivo(id);
            if(insumoGestionCultivo == null) return NotFound();
            return Ok(insumoGestionCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsumoGestionCultivo(
            [Required] int IdGestionCultivo,
            [Required] int IdTipoInsumoGestionCultivo,
            [Required][MaxLength(50)] string Nombre,
            [Required][MaxLength(50)] string Dosis,
            [Required][MaxLength(50)] string Unidad
            
                       )
        {
            var insumoGestionCultivo = await insumoGestionCultivoService.CreateInsumoGestionCultivo(IdGestionCultivo, IdTipoInsumoGestionCultivo, Nombre, Dosis, Unidad);
            return CreatedAtAction(nameof(GetInsumoGestionCultivo), new { id = insumoGestionCultivo.IdInsumoGestionCultivo }, insumoGestionCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutInsumoGestionCultivo(
            [Required] int IdInsumoGestionCultivo,
            [Required] int IdGestionCultivo,
            [Required] int? IdTipoInsumoGestionCultivo,
            [Required][MaxLength(50)] string? Nombre,
            [Required][MaxLength(50)] string? Dosis,
            [Required][MaxLength(50)] string? Unidad
                       )
        {
            var insumoGestionCultivo = await insumoGestionCultivoService.PutInsumoGestionCultivo(IdInsumoGestionCultivo, IdGestionCultivo,IdTipoInsumoGestionCultivo, Nombre, Dosis, Unidad);
            return Ok(insumoGestionCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInsumoGestionCultivo(int id)
        {
            var insumoGestionCultivo = await insumoGestionCultivoService.DeleteInsumoGestionCultivo(id);
            if(insumoGestionCultivo == null) return NotFound();
            return Ok(insumoGestionCultivo);
        }
    }
    
}
