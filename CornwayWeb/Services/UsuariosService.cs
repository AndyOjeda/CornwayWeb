using CornwayWeb.Model;
using CornwayWeb.Repositories;

namespace CornwayWeb.Services
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuarios>> GetUsuarios();
        Task<Usuarios?> GetUsuario(int id);
        Task<Usuarios> CreateUsuario(
                       string Nombres,
                                  string Apellidos,
                                             string Correo,
                                                        string Clave,
                                                                   int IdTipoUsuario
                       );
        Task<Usuarios> PutUsuario(
            int IdUsuario,
            string? Nombres,
              string? Apellidos,
                  string? Correo,
                      string? Clave,
                        int? IdTipoUsuario
                          );
        Task<Usuarios?> DeleteUsuario(int id);
    }
    public class UsuariosService(IUsuariosRepository usuariosRepository) : IUsuariosService
    {
        public async Task<Usuarios?> GetUsuario(int id)
        {
            return await usuariosRepository.GetUsuario(id);
        }

        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            return await usuariosRepository.GetUsuarios();
        }

        public async Task<Usuarios> CreateUsuario(
                  string Nombres,
                  string Apellidos,
                   string Correo,
                   string Clave,
                   int IdTipoUsuario
                                   )
        {
            return await usuariosRepository.CreateUsuario(new Usuarios
            {
                Nombres = Nombres,
                Apellidos = Apellidos,
                Correo = Correo,
                Clave = Clave,
                IdTipoUsuario = IdTipoUsuario
            });
        }

        public async Task<Usuarios> PutUsuario(
                       int IdUsuario,
                                  string? Nombres,
                            string? Apellidos,
                              string? Correo,
                                 string? Clave,
                                   int? IdTipoUsuario
                                    )
        {
            Usuarios? usuario = await usuariosRepository.GetUsuario(IdUsuario);
            if (usuario == null) throw new Exception("Usuario no encontrado");

            usuario.Nombres = Nombres ?? usuario.Nombres;
            usuario.Apellidos = Apellidos ?? usuario.Apellidos;
            usuario.Correo = Correo ?? usuario.Correo;
            usuario.Clave = Clave ?? usuario.Clave;
            usuario.IdTipoUsuario = IdTipoUsuario ?? usuario.IdTipoUsuario;
            return await usuariosRepository.PutUsuario(usuario);
        }

        public async Task<Usuarios?> DeleteUsuario(int id)
        {
            return await usuariosRepository.DeleteUsuario(id);
        }
    }

}
