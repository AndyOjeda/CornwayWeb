using CornwayWeb.Model;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface ITiposCultivoRepository
    {
        Task<IEnumerable<TiposCultivo>> GetTiposCultivos();
        Task<TiposCultivo?> GetTiposCultivo(int id);
        Task<TiposCultivo> CreateTiposCultivo(TiposCultivo tiposCultivo);
        Task<TiposCultivo> PutTiposCultivo(TiposCultivo tiposCultivo);
        Task<TiposCultivo?> DeleteTiposCultivo(int id);
    }
    public class TiposCultivoRepository : ITiposCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public TiposCultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TiposCultivo?> GetTiposCultivo(int id)
        {
            return await _db.TiposCultivo.FindAsync(id);
        }

        public async Task<IEnumerable<TiposCultivo>> GetTiposCultivos()
        {
            return await _db.TiposCultivo.ToListAsync();
        }

        public async Task<TiposCultivo> CreateTiposCultivo(TiposCultivo tiposCultivo)
        {
            _db.TiposCultivo.Add(tiposCultivo);
            await _db.SaveChangesAsync();
            return tiposCultivo;
        }

        public async Task<TiposCultivo> PutTiposCultivo(TiposCultivo tiposCultivo)
        {
            _db.Entry(tiposCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tiposCultivo;
        }

        public async Task<TiposCultivo?> DeleteTiposCultivo(int id)
        {
            TiposCultivo? tiposCultivo = await _db.TiposCultivo.FindAsync(id);
            if (tiposCultivo == null) return tiposCultivo;
            tiposCultivo.IsActive = false;
            _db.Entry(tiposCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tiposCultivo;
        }
    }
    
}
