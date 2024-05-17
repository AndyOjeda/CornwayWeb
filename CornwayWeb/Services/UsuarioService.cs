using CornwayWeb.Repositories;
using CornwayWeb.Model;

namespace CornwayWeb.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario?> GetUsuario(int id);
        Task<Usuario> CreateUsuario(
            string Nombres,
            string Apellidos,
            string Correo,
            string Clave
                       );
        Task<Usuario> PutUsuario(

            int IdUsuario,
            string? Nombres,
            string? Apellidos,
            string? Correo,
            string? Clave
                       );
        Task<Usuario?> DeleteUsuario(int id);
    }
    public class UsuarioService(UsuarioRepository usuarioRepository) : IUsuarioService
    {
        public async Task<Usuario?> GetUsuario(int id)
        {
            return await usuarioRepository.GetUsuario(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await usuarioRepository.GetUsuarios();
        }

        public async Task<Usuario> CreateUsuario(
            string Nombres,
            string Apellidos,
            string Correo,
            string Clave
                                             )
        {
            return await usuarioRepository.CreateUsuario(new Usuario
            {
                Nombres = Nombres,
                Apellidos = Apellidos,
                Correo = Correo,
                Clave = Clave
            });
        }

        public async Task<Usuario> PutUsuario(
            int IdUsuario,
            string? Nombres,
            string? Apellidos,
            string? Correo,
            string? Clave
            )
        {
            Usuario? usuario = await usuarioRepository.GetUsuario(IdUsuario);
            if (usuario == null) throw new Exception("Usuario not found");

            usuario.Nombres = Nombres ?? usuario.Nombres;
            usuario.Apellidos = Apellidos ?? usuario.Apellidos;
            usuario.Correo = Correo ?? usuario.Correo;
            usuario.Clave = Clave ?? usuario.Clave;
            return await usuarioRepository.PutUsuario(usuario);
        }

        public async Task<Usuario?> DeleteUsuario(int id)
        {
            return await usuarioRepository.DeleteUsuario(id);
        }
    }
    
}
