using CornwayWeb.Context;
using CornwayWeb.Model;
using CornwayWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface IInsumoCultivoRepository
    {
        Task<IEnumerable<InsumoCultivo>> GetInsumoCultivos();
        Task<InsumoCultivo?> GetInsumoCultivo(int id);
        Task<InsumoCultivo> CreateInsumoCultivo(InsumoCultivo insumoCultivo);
        Task<InsumoCultivo> PutInsumoCultivo(InsumoCultivo insumoCultivo);
        Task<InsumoCultivo?> DeleteInsumoCultivo(int id);
    }
    public class InsumoCultivoRepository : IInsumoCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public InsumoCultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async  Task<InsumoCultivo?> GetInsumoCultivo(int id)
        {
            return await _db.InsumoCultivos.FindAsync(id);
        }

        public async Task<IEnumerable<InsumoCultivo>> GetInsumoCultivos()
        {
            return await _db.InsumoCultivos.ToListAsync();
        }

        public async Task<InsumoCultivo> CreateInsumoCultivo(InsumoCultivo insumoCultivo)
        {
            _db.InsumoCultivos.Add(insumoCultivo);
            await _db.SaveChangesAsync();
            return insumoCultivo;
        }

        public async Task<InsumoCultivo> PutInsumoCultivo(InsumoCultivo insumoCultivo)
        {
            _db.Entry(insumoCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return insumoCultivo;
        }

        public async Task<InsumoCultivo?> DeleteInsumoCultivo(int id)
        {
            InsumoCultivo? insumoCultivo = await _db.InsumoCultivos.FindAsync(id);
            if (insumoCultivo == null) return insumoCultivo;
            insumoCultivo.IsActive = false;
            _db.Entry(insumoCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return insumoCultivo;
        }
    }
}
