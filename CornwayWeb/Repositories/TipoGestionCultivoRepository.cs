using CornwayWeb.Context;
using CornwayWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface ITipoGestionCultivoRepository
    {
        Task<IEnumerable<TipoGestionCultivo>> GetTipoGestionCultivos();
        Task<TipoGestionCultivo?> GetTipoGestionCultivo(int id);
        Task<TipoGestionCultivo> CreateTipoGestionCultivo(TipoGestionCultivo tipoGestionCultivo);
        Task<TipoGestionCultivo> PutTipoGestionCultivo(TipoGestionCultivo tipoGestionCultivo);
        Task<TipoGestionCultivo?> DeleteTipoGestionCultivo(int id);
    }
    public class TipoGestionCultivoRepository : ITipoGestionCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public TipoGestionCultivoRepository (ApplicationDbContext db)
        {
            _db = db;
        }

        public async  Task<TipoGestionCultivo?> GetTipoGestionCultivo(int id)
        {
            return await _db.TipoGestionCultivos.FindAsync(id);
        }

        public async Task<IEnumerable<TipoGestionCultivo>> GetTipoGestionCultivos()
        {
            return await _db.TipoGestionCultivos.ToListAsync();
        }

        public async Task<TipoGestionCultivo> CreateTipoGestionCultivo(TipoGestionCultivo tipoGestionCultivo)
        {
            _db.TipoGestionCultivos.Add(tipoGestionCultivo);
            await _db.SaveChangesAsync();
            return tipoGestionCultivo;
        }

        public async Task<TipoGestionCultivo> PutTipoGestionCultivo(TipoGestionCultivo tipoGestionCultivo)
        {
            _db.Entry(tipoGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tipoGestionCultivo;
        }

        public async Task<TipoGestionCultivo?> DeleteTipoGestionCultivo(int id)
        {
            TipoGestionCultivo? tipoGestionCultivo = await _db.TipoGestionCultivos.FindAsync(id);
            if (tipoGestionCultivo == null) return tipoGestionCultivo;
            tipoGestionCultivo.IsActive = false;
            _db.Entry(tipoGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tipoGestionCultivo;
        }
    }   
   
}