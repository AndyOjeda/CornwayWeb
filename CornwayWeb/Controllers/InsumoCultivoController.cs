using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Models;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoCultivoController(IInsumoCultivoService insumoCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetInsumoCultivos()
        {
            IEnumerable<InsumoCultivo> insumoCultivos = await insumoCultivoService.GetInsumoCultivos();
            return Ok(insumoCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsumoCultivo(int id)
        {
            InsumoCultivo? insumoCultivo = await insumoCultivoService.GetInsumoCultivo(id);
            if(insumoCultivo == null) return NotFound();
            return Ok(insumoCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsumoCultivo(

            [Required] int IdTipoInsumoGestionCultivo,
            [Required] int Cantidad
            )
        {
            var insumoCultivo = await insumoCultivoService.CreateInsumoCultivo(IdTipoInsumoGestionCultivo, Cantidad);
            return CreatedAtAction(nameof(GetInsumoCultivo), new { id = insumoCultivo.IdInsumoCultivo }, insumoCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutInsumoCultivo(
            [Required] int IdInsumoCultivo,
            [Required] int? IdTipoInsumoGestionCultivo,
            [Required] int? Cantidad
            )
        {
            var insumoCultivo = await insumoCultivoService.PutInsumoCultivo(IdInsumoCultivo, IdTipoInsumoGestionCultivo, Cantidad);
            return Ok(insumoCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInsumoCultivo(int id)
        {
            var insumoCultivo = await insumoCultivoService.DeleteInsumoCultivo(id);
            if(insumoCultivo == null) return NotFound();
            return Ok(insumoCultivo);
        }

    }
    
}
