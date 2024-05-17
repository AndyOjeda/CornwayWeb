using CornwayWeb.Model;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface ITiposInsumoGestionCultivoRepository
    {
        Task<IEnumerable<TiposInsumoGestionCultivo>> GetTiposInsumoGestionCultivos();
        Task<TiposInsumoGestionCultivo?> GetTiposInsumoGestionCultivo(int id);
        Task<TiposInsumoGestionCultivo> CreateTiposInsumoGestionCultivo(TiposInsumoGestionCultivo tiposInsumoGestionCultivo);
        Task<TiposInsumoGestionCultivo> PutTiposInsumoGestionCultivo(TiposInsumoGestionCultivo tiposInsumoGestionCultivo);
        Task<TiposInsumoGestionCultivo?> DeleteTiposInsumoGestionCultivo(int id);
    }
    public class TiposInsumoGestionCultivoRepository : ITiposInsumoGestionCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public TiposInsumoGestionCultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TiposInsumoGestionCultivo?> GetTiposInsumoGestionCultivo(int id)
        {
            return await _db.TiposInsumoGestionCultivos.FindAsync(id);
        }

        public async Task<IEnumerable<TiposInsumoGestionCultivo>> GetTiposInsumoGestionCultivos()
        {
            return await _db.TiposInsumoGestionCultivos.ToListAsync();
        }

        public async Task<TiposInsumoGestionCultivo> CreateTiposInsumoGestionCultivo(TiposInsumoGestionCultivo tiposInsumoGestionCultivo)
        {
            _db.TiposInsumoGestionCultivos.Add(tiposInsumoGestionCultivo);
            await _db.SaveChangesAsync();
            return tiposInsumoGestionCultivo;
        }

        public async Task<TiposInsumoGestionCultivo> PutTiposInsumoGestionCultivo(TiposInsumoGestionCultivo tiposInsumoGestionCultivo)
        {
            _db.Entry(tiposInsumoGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tiposInsumoGestionCultivo;
        }

        public async Task<TiposInsumoGestionCultivo?> DeleteTiposInsumoGestionCultivo(int id)
        {
            TiposInsumoGestionCultivo? tiposInsumoGestionCultivo = await _db.TiposInsumoGestionCultivos.FindAsync(id);
            if (tiposInsumoGestionCultivo == null) return tiposInsumoGestionCultivo;
            tiposInsumoGestionCultivo.IsActive = false;
            _db.Entry(tiposInsumoGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tiposInsumoGestionCultivo;
        }
    }
    
}
