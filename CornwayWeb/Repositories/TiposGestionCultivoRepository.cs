using CornwayWeb.Model;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface ITiposGestionCultivoRepository
    {
        Task<IEnumerable<TiposGestionCultivo>> GetTipoGestionCultivos();
        Task<TiposGestionCultivo?> GetTipoGestionCultivo(int id);
        Task<TiposGestionCultivo> CreateTipoGestionCultivo(TiposGestionCultivo tiposGestionCultivo);
        Task<TiposGestionCultivo> PutTipoGestionCultivo(TiposGestionCultivo tiposGestionCultivo);
        Task<TiposGestionCultivo?> DeleteTipoGestionCultivo(int id);
    }
    public class TiposGestionCultivoRepository : ITiposGestionCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public TiposGestionCultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TiposGestionCultivo?> GetTipoGestionCultivo(int id)
        {
            return await _db.TiposGestionCultivos.FindAsync(id);
        }

        public async Task<IEnumerable<TiposGestionCultivo>> GetTipoGestionCultivos()
        {
            return await _db.TiposGestionCultivos.ToListAsync();
        }

        public async Task<TiposGestionCultivo> CreateTipoGestionCultivo(TiposGestionCultivo tiposGestionCultivo)
        {
            _db.TiposGestionCultivos.Add(tiposGestionCultivo);
            await _db.SaveChangesAsync();
            return tiposGestionCultivo;
        }

        public async Task<TiposGestionCultivo> PutTipoGestionCultivo(TiposGestionCultivo tiposGestionCultivo)
        {
            _db.Entry(tiposGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tiposGestionCultivo;
        }

        public async Task<TiposGestionCultivo?> DeleteTipoGestionCultivo(int id)
        {
            TiposGestionCultivo? tiposGestionCultivo = await _db.TiposGestionCultivos.FindAsync(id);
            if (tiposGestionCultivo == null) return tiposGestionCultivo;
            tiposGestionCultivo.IsActive = false;
            _db.Entry(tiposGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tiposGestionCultivo;
        }
    }
}
