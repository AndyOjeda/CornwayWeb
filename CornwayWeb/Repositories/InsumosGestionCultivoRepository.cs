using CornwayWeb.Model;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface IInsumosGestionCultivoRepository
    {
        Task<IEnumerable<InsumosGestionCultivo>> GetInsumosGestionCultivos();
        Task<InsumosGestionCultivo?> GetInsumosGestionCultivo(int id);
        Task<InsumosGestionCultivo> CreateInsumosGestionCultivo(InsumosGestionCultivo insumosGestionCultivo);
        Task<InsumosGestionCultivo> PutInsumosGestionCultivo(InsumosGestionCultivo insumosGestionCultivo);
        Task<InsumosGestionCultivo?> DeleteInsumosGestionCultivo(int id);
    }
    public class InsumosGestionCultivoRepository : IInsumosGestionCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public InsumosGestionCultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<InsumosGestionCultivo?> GetInsumosGestionCultivo(int id)
        {
            return await _db.InsumosGestionCultivos.FindAsync(id);
        }

        public async Task<IEnumerable<InsumosGestionCultivo>> GetInsumosGestionCultivos()
        {
            return await _db.InsumosGestionCultivos.ToListAsync();
        }

        public async Task<InsumosGestionCultivo> CreateInsumosGestionCultivo(InsumosGestionCultivo insumosGestionCultivo)
        {
            _db.InsumosGestionCultivos.Add(insumosGestionCultivo);
            await _db.SaveChangesAsync();
            return insumosGestionCultivo;
        }

        public async Task<InsumosGestionCultivo> PutInsumosGestionCultivo(InsumosGestionCultivo insumosGestionCultivo)
        {
            _db.Entry(insumosGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return insumosGestionCultivo;
        }

        public async Task<InsumosGestionCultivo?> DeleteInsumosGestionCultivo(int id)
        {
            InsumosGestionCultivo? insumosGestionCultivo = await _db.InsumosGestionCultivos.FindAsync(id);
            if (insumosGestionCultivo == null) return insumosGestionCultivo;
            insumosGestionCultivo.IsActive = false;
            _db.Entry(insumosGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return insumosGestionCultivo;
        }
    }
    
}
