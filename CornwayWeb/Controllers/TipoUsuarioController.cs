using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController(ITipoUsuarioService tipoUsuarioService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTipoUsuarios()
        {
            IEnumerable<TipoUsuario> tipoUsuarios = await tipoUsuarioService.GetTipoUsuarios();
            return Ok(tipoUsuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoUsuario(int id)
        {
            TipoUsuario? tipoUsuario = await tipoUsuarioService.GetTipoUsuario(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }
            return Ok(tipoUsuario);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipoUsuario(
            [FromForm][Required] string Nombre
            )
        {
            var tipoUsuario = await tipoUsuarioService.CreateTipoUsuario(Nombre);
            return CreatedAtAction(nameof(GetTipoUsuario), new { id = tipoUsuario.IdTipoUsuario }, tipoUsuario);
        }

        [HttpPut]
        public async Task<IActionResult> PutTipoUsuario(
            [FromForm][Required] int IdTipoUsuario,
            [FromForm][Required] string Nombre
            )
        {
            var tipoUsuario = await tipoUsuarioService.PutTipoUsuario(IdTipoUsuario, Nombre);
            return Ok(tipoUsuario);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTipoUsuario(int id)
        {
            var tipoUsuario = await tipoUsuarioService.DeleteTipoUsuario(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }
            return Ok(tipoUsuario);
        }
    }
    
}
