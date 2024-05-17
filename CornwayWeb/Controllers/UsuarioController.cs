using System.ComponentModel.DataAnnotations;
using CornwayWeb.Model;
using CornwayWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornwayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            IEnumerable<Usuario> usuarios = await usuarioService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            Usuario? usuario = await usuarioService.GetUsuario(id);
            if(usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario(
            [Required] int IdTipoUsuario,
            [Required][MaxLength(50)] string Nombres,
            [Required][MaxLength(50)] string Apellidos,
            [Required][MaxLength(300)][EmailAddress(ErrorMessage = "Invalid email address")] string Correo,
            [Required][MaxLength(50)] string Clave
            )
        {
            var usuario = await usuarioService.CreateUsuario(IdTipoUsuario, Nombres, Apellidos, Correo, Clave);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpPut]
        public async Task<IActionResult> PutUsuario(
            [Required] int IdUsuario,
            [Required] int? IdTipoUsuario,
            [MaxLength(50)] string? Nombres,
            [MaxLength(50)] string? Apellidos,
            [MaxLength(300)][EmailAddress(ErrorMessage = "Invalid email address")] string? Correo,
            [MaxLength(50)] string? Clave
            )
        {
            var usuario = await usuarioService.PutUsuario(IdUsuario, IdTipoUsuario, Nombres, Apellidos, Correo, Clave);
            return Ok(usuario);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await usuarioService.DeleteUsuario(id);
            if(usuario == null) return NotFound();
            return Ok(usuario);
        }

    }
    
}
