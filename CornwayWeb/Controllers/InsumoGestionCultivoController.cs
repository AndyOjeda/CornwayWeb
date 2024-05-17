using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoGestionCultivoController(IInsumosGestionCultivoService insumosGestionCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetInsumosGestionCultivos()
        {
            IEnumerable<InsumosGestionCultivo> insumosGestionCultivos = await insumosGestionCultivoService.GetInsumosGestionCultivos();
            return Ok(insumosGestionCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsumoGestionCultivo(int id)
        {
            InsumosGestionCultivo? insumoGestionCultivo = await insumosGestionCultivoService.GetInsumoGestionCultivo(id);
            if (insumoGestionCultivo == null)
            {
                return NotFound();
            }
            return Ok(insumoGestionCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsumoGestionCultivo(
            [Required] int IdGestionCultivo,
            [Required] int IdInsumoCultivo,
            [Required][MaxLength(50)] string Nombre,
            [Required] double Dosis,
            [Required][MaxLength(50)] string Unidad
                                             )
        {
            var insumoGestionCultivo = await insumosGestionCultivoService.CreateInsumoGestionCultivo(IdGestionCultivo, IdInsumoCultivo, Nombre, Dosis, Unidad);
            return CreatedAtAction(nameof(GetInsumoGestionCultivo), new { id = insumoGestionCultivo.IdInsumoGestionCultivo }, insumoGestionCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutInsumoGestionCultivo(
            [Required] int IdInsumoGestionCultivo,
            [Required] int IdGestionCultivo,
            [Required] int IdInsumoCultivo,
            [MaxLength(50)] string Nombre,
            [Required] double Dosis,
            [MaxLength(50)] string Unidad
                                                    )
        {
            var insumoGestionCultivo = await insumosGestionCultivoService.PutInsumoGestionCultivo(IdInsumoGestionCultivo, IdGestionCultivo, IdInsumoCultivo, Nombre, Dosis, Unidad);
            return Ok(insumoGestionCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInsumoGestionCultivo(int id)
        {
            var insumoGestionCultivo = await insumosGestionCultivoService.DeleteInsumoGestionCultivo(id);
            if (insumoGestionCultivo == null)
            {
                return NotFound();
            }
            return Ok(insumoGestionCultivo);
        }
    }
    
}
