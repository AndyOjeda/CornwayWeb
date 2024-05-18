using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController(IUsuariosService  usuariosService) : ControllerBase 
    {
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            IEnumerable<Usuarios> usuarios = await usuariosService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            Usuarios? usuario = await usuariosService.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario(
            [FromForm][Required][MaxLength(50)] string Nombres,
            [FromForm][Required][MaxLength(50)] string Apellidos,
            [FromForm][Required][MaxLength(50)] string Correo,
            [FromForm][Required][MaxLength(50)] string Clave,
            [FromForm][Required] int IdTipoUsuario
                                 )
        {
            var usuario = await usuariosService.CreateUsuario(Nombres, Apellidos, Correo, Clave, IdTipoUsuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpPut]
        public async Task<IActionResult> PutUsuario(
            [FromForm][Required] int IdUsuario,
            [FromForm][MaxLength(50)] string? Nombres,
            [FromForm][MaxLength(50)] string? Apellidos,
            [FromForm][MaxLength(50)] string? Correo,
            [FromForm][MaxLength(50)] string? Clave,
            [FromForm][Required] int IdTipoUsuario
                                      )
        {
            var usuario = await usuariosService.PutUsuario(IdUsuario, Nombres, Apellidos, Correo, Clave, IdTipoUsuario);
            return Ok(usuario);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await usuariosService.DeleteUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromForm] Auth auth)
        {
            var result = await usuariosService.Authenticate(auth);
            if (result)
            {
                return Ok();
            }
            return Unauthorized();

        }
    }
}
