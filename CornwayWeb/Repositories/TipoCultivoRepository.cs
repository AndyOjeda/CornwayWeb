using CornwayWeb.Context;
using CornwayWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface ITipoCultivoRepository
    {
        Task<IEnumerable<TipoCultivo>> GetTipoCultivos();
        Task<TipoCultivo?> GetTipoCultivo(int id);
        Task<TipoCultivo> CreateTipoCultivo(TipoCultivo tipoCultivo);
        Task<TipoCultivo> PutTipoCultivo(TipoCultivo tipoCultivo);
        Task<TipoCultivo?> DeleteTipoCultivo(int id);
    }
    public class TipoCultivoRepository : ITipoCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public TipoCultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async  Task<TipoCultivo?> GetTipoCultivo(int id)
        {
            return await _db.TipoCultivos.FindAsync(id);
        }

        public async Task<IEnumerable<TipoCultivo>> GetTipoCultivos()
        {
            return await _db.TipoCultivos.ToListAsync();
        }

        public async Task<TipoCultivo> CreateTipoCultivo(TipoCultivo tipoCultivo)
        {
            _db.TipoCultivos.Add(tipoCultivo);
            await _db.SaveChangesAsync();
            return tipoCultivo;
        }

        public async Task<TipoCultivo> PutTipoCultivo(TipoCultivo tipoCultivo)
        {
            _db.Entry(tipoCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tipoCultivo;
        }

        public async Task<TipoCultivo?> DeleteTipoCultivo(int id)
        {
            TipoCultivo? tipoCultivo = await _db.TipoCultivos.FindAsync(id);
            if (tipoCultivo == null) return tipoCultivo;
            tipoCultivo.IsActive = false;
            _db.Entry(tipoCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return tipoCultivo;
        }
    }
    
}

