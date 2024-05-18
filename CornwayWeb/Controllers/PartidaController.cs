using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidaController(IPartidaService partidaService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPartidas()
        {
            IEnumerable<Partida> partidas = await partidaService.GetPartidas();
            return Ok(partidas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartida(int id)
        {
            Partida? partida = await partidaService.GetPartida(id);
            if(partida == null) return NotFound();
            return Ok(partida);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartida(
            [Required] int IdCosecha,
            [Required] int Monedas
            )
        {
            var partida = await partidaService.CreatePartida(IdCosecha, Monedas);
            return CreatedAtAction(nameof(GetPartida), new { id = partida.IdPartida }, partida);
        }

        [HttpPut]
        public async Task<IActionResult> PutPartida(
                       [Required] int IdPartida,
                                  [Required] int IdCosecha,
                                  [Required] int Monedas
                       )
        {
            var partida = await partidaService.PutPartida(IdPartida, IdCosecha, Monedas);
            return Ok(partida);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePartida(int id)
        {
            var partida = await partidaService.DeletePartida(id);
            if(partida == null) return NotFound();
            return Ok(partida);
        }
    }
}
