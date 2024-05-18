using CornwayWeb.Model;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuarios>> GetUsuarios();
        Task<Usuarios?> GetUsuario(int id);
        Task<Usuarios> CreateUsuario(Usuarios usuario);
        Task<Usuarios> PutUsuario(Usuarios usuario);
        Task<Usuarios?> DeleteUsuario(int id);
        Task<bool> Authenticate(Auth auth);
    }
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuariosRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Usuarios?> GetUsuario(int id)
        {
            return await _db.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            return await _db.Usuarios.ToListAsync();
        }

        public async Task<Usuarios> CreateUsuario(Usuarios usuario)
        {
            _db.Usuarios.Add(usuario);
            await _db.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuarios> PutUsuario(Usuarios usuario)
        {
            _db.Entry(usuario).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuarios?> DeleteUsuario(int id)
        {
            Usuarios? usuario = await _db.Usuarios.FindAsync(id);
            if (usuario == null) return usuario;
            usuario.IsActive = false;
            _db.Entry(usuario).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Authenticate(Auth auth)
        {
            var usuario = await _db.Usuarios.SingleOrDefaultAsync(u => u.Correo == auth.Correo && u.Clave == auth.Clave);
            return usuario != null;
        }
    }
}
