using CornwayWeb.Context;
using CornwayWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario?> GetUsuario(int id);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task<Usuario> PutUsuario(Usuario usuario);
        Task<Usuario?> DeleteUsuario(int id);
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async  Task<Usuario?> GetUsuario(int id)
        {
            return await _db.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _db.Usuarios.ToListAsync();
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            await _db.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> PutUsuario(Usuario usuario)
        {
            _db.Entry(usuario).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> DeleteUsuario(int id)
        {
            Usuario? usuario = await _db.Usuarios.FindAsync(id);
            if (usuario == null) return usuario;
            usuario.IsActive = false;
            _db.Entry(usuario).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return usuario;
        }
    }
}
