using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionesCultivoController(IGestionesCultivoService gestionesCultivoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGestionesCultivos()
        {
            IEnumerable<GestionesCultivo> gestionesCultivos = await gestionesCultivoService.GetGestionesCultivo();
            return Ok(gestionesCultivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGestionesCultivo(int id)
        {
            GestionesCultivo? gestionesCultivo = await gestionesCultivoService.GetGestionesCultivo(id);
            if (gestionesCultivo == null)
            {
                return NotFound();
            }
            return Ok(gestionesCultivo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGestionesCultivo(
            [FromForm][Required] int IdCultivo,
            [FromForm][Required] int IdTipoGestionCultivo,
            [FromForm][Required] int IdInsumoGestionCultivo,
            [FromForm][Required] DateOnly FechaGestion,
            [FromForm][Required][MaxLength(50)] string Comentario
            )
        {
            var gestionesCultivo = await gestionesCultivoService.CreateGestionesCultivo(IdCultivo, IdTipoGestionCultivo, IdInsumoGestionCultivo, FechaGestion, Comentario);
            return CreatedAtAction(nameof(GetGestionesCultivo), new { id = gestionesCultivo.IdGestionCultivo }, gestionesCultivo);
        }

        [HttpPut]
        public async Task<IActionResult> PutGestionesCultivo(
            [FromForm][Required] int IdGestionCultivo,
            [FromForm][Required] int IdCultivo,
            [FromForm][Required] int IdTipoGestionCultivo,
            [FromForm][Required] int IdInsumoGestionCultivo,
            [FromForm][Required] DateOnly FechaGestion,
            [FromForm][MaxLength(50)] string Comentario
                                                    )
        {
            var gestionesCultivo = await gestionesCultivoService.PutGestionesCultivo(IdGestionCultivo, IdCultivo, IdTipoGestionCultivo, IdInsumoGestionCultivo, FechaGestion, Comentario);
            return Ok(gestionesCultivo);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGestionesCultivo(int id)
        {
            var gestionesCultivo = await gestionesCultivoService.DeleteGestionesCultivo(id);
            if (gestionesCultivo == null)
            {
                return NotFound();
            }
            return Ok(gestionesCultivo);
        }
    }
    
}
