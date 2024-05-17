using CornwayWeb.Repositories;
using CornwayWeb.Model;

namespace CornwayWeb.Services
{
    public interface ITipoUsuarioService
    {
        Task<IEnumerable<TipoUsuario>> GetTipoUsuarios();
        Task<TipoUsuario?> GetTipoUsuario(int id);
        Task<TipoUsuario> CreateTipoUsuario(
            string Nombre
            );
        Task<TipoUsuario> PutTipoUsuario(

            int IdTipoUsuario,
            string? Nombre
            );
        Task<TipoUsuario?> DeleteTipoUsuario(int id);
    }
    public class TipoUsuarioService(ITipoUsuarioRepository tipoUsuarioRepository) : ITipoUsuarioService
    {
        public async Task<TipoUsuario?> GetTipoUsuario(int id)
        {
            return await tipoUsuarioRepository.GetTipoUsuario(id);
        }

        public async Task<IEnumerable<TipoUsuario>> GetTipoUsuarios()
        {
            return await tipoUsuarioRepository.GetTipoUsuarios();
        }

        public async Task<TipoUsuario> CreateTipoUsuario(

            string Nombre
            )
        {
            return await tipoUsuarioRepository.CreateTipoUsuario(new TipoUsuario
            {
                Nombre = Nombre
            });
        }

        public async Task<TipoUsuario> PutTipoUsuario(

            int IdTipoUsuario,
            string? Nombre
            )
        {
            TipoUsuario? tipoUsuario = await tipoUsuarioRepository.GetTipoUsuario(IdTipoUsuario);
            if (tipoUsuario == null) throw new Exception("TipoUsuario not found");

            tipoUsuario.Nombre = Nombre ?? tipoUsuario.Nombre;
            return await tipoUsuarioRepository.PutTipoUsuario(tipoUsuario);
        }

        public async Task<TipoUsuario?> DeleteTipoUsuario(int id)
        {
            return await tipoUsuarioRepository.DeleteTipoUsuario(id);
        }
    }
    
}
