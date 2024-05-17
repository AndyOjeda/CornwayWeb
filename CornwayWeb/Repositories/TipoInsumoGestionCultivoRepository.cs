using CornwayWeb.Context;
using CornwayWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface ITipoInsumoGestionCultivoRepository
    {
        Task<IEnumerable<TipoInsumoGestionCultivo>> GetTipoInsumoGestionCultivos();
        Task<TipoInsumoGestionCultivo?> GetTipoInsumoGestionCultivo(int id);
        Task<TipoInsumoGestionCultivo> CreateTipoInsumoGestionCultivo(TipoInsumoGestionCultivo tipoInsumoGestionCultivo);
        Task<TipoInsumoGestionCultivo> PutTipoInsumoGestionCultivo(TipoInsumoGestionCultivo tipoInsumoGestionCultivo);
        Task<TipoInsumoGestionCultivo?> DeleteTipoInsumoGestionCultivo(int id);
    }
    public class TipoInsumoGestionCultivoRepository : ITipoInsumoGestionCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public TipoInsumoGestionCultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async  Task<TipoInsumoGestionCultivo?> GetTipoInsumoGestionCultivo(int id)
        {
            return await _db.TipoInsumoGestionCultivos.FindAsync(id);
        }

        public async Task<IEnumerable<TipoInsumoGestionCultivo>> GetTipoInsumoGestionCultivos()
        {
            return await _db.TipoInsumoGestionCultivos.ToListAsync();
        }

        public async Task<TipoInsumoGestionCultivo> CreateTipoInsumoGestionCultivo(TipoInsumoGestionCultivo tipoInsumoGestionCultivo)
        {
            _db.TipoInsumoGestionCultivos.Add(tipoInsumoGestionCultivo);
            await _db.SaveChangesAsync();
            return tipoInsumoGestionCultivo;
        }

        public async Task<TipoInsumoGestionCultivo> PutTipoInsumoGestionCultivo(TipoInsumoGestionCultivo tipoInsumoGestionCultivo)
        {
            _db.Entry(tipoInsumoGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tipoInsumoGestionCultivo;
        }

        public async Task<TipoInsumoGestionCultivo?> DeleteTipoInsumoGestionCultivo(int id)
        {
            TipoInsumoGestionCultivo? tipoInsumoGestionCultivo = await _db.TipoInsumoGestionCultivos.FindAsync(id);
            if (tipoInsumoGestionCultivo == null) return tipoInsumoGestionCultivo;
            tipoInsumoGestionCultivo.IsActive = false;
            _db.Entry(tipoInsumoGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tipoInsumoGestionCultivo;
        }
    }

}
