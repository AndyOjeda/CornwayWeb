using CornwayWeb.Context;
using CornwayWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface ITipoUsuarioRepository
    {
        Task<IEnumerable<TipoUsuario>> GetTipoUsuarios();
        Task<TipoUsuario?> GetTipoUsuario(int id);
        Task<TipoUsuario> CreateTipoUsuario(TipoUsuario tipoUsuario);
        Task<TipoUsuario> PutTipoUsuario(TipoUsuario tipoUsuario);
        Task<TipoUsuario?> DeleteTipoUsuario(int id);
    }
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public TipoUsuarioRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async  Task<TipoUsuario?> GetTipoUsuario(int id)
        {
            return await _db.TipoUsuarios.FindAsync(id);
        }

        public async Task<IEnumerable<TipoUsuario>> GetTipoUsuarios()
        {
            return await _db.TipoUsuarios.ToListAsync();
        }

        public async Task<TipoUsuario> CreateTipoUsuario(TipoUsuario tipoUsuario)
        {
            _db.TipoUsuarios.Add(tipoUsuario);
            await _db.SaveChangesAsync();
            return tipoUsuario;
        }

        public async Task<TipoUsuario> PutTipoUsuario(TipoUsuario tipoUsuario)
        {
            _db.Entry(tipoUsuario).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tipoUsuario;
        }

        public async Task<TipoUsuario?> DeleteTipoUsuario(int id)
        {
            TipoUsuario? tipoUsuario = await _db.TipoUsuarios.FindAsync(id);
            if (tipoUsuario == null) return tipoUsuario;
            tipoUsuario.IsActive = false;
            _db.Entry(tipoUsuario).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tipoUsuario;
        }
    }
}
