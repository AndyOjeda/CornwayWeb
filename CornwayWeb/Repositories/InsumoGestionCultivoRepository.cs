using CornwayWeb.Context;
using CornwayWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface IInsumoGestionCultivoRepository
    {
        Task<IEnumerable<InsumoGestionCultivo>> GetInsumoGestionCultivos();
        Task<InsumoGestionCultivo?> GetInsumoGestionCultivo(int id);
        Task<InsumoGestionCultivo> CreateInsumoGestionCultivo(InsumoGestionCultivo insumoGestionCultivo);
        Task<InsumoGestionCultivo> PutInsumoGestionCultivo(InsumoGestionCultivo insumoGestionCultivo);
        Task<InsumoGestionCultivo?> DeleteInsumoGestionCultivo(int id);
    }
    public class InsumoGestionCultivoRepository : IInsumoGestionCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public InsumoGestionCultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async  Task<InsumoGestionCultivo?> GetInsumoGestionCultivo(int id)
        {
            return await _db.InsumoGestionCultivos.FindAsync(id);
        }

        public async Task<IEnumerable<InsumoGestionCultivo>> GetInsumoGestionCultivos()
        {
            return await _db.InsumoGestionCultivos.ToListAsync();
        }

        public async Task<InsumoGestionCultivo> CreateInsumoGestionCultivo(InsumoGestionCultivo insumoGestionCultivo)
        {
            _db.InsumoGestionCultivos.Add(insumoGestionCultivo);
            await _db.SaveChangesAsync();
            return insumoGestionCultivo;
        }

        public async Task<InsumoGestionCultivo> PutInsumoGestionCultivo(InsumoGestionCultivo insumoGestionCultivo)
        {
            _db.Entry(insumoGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return insumoGestionCultivo;
        }

        public async Task<InsumoGestionCultivo?> DeleteInsumoGestionCultivo(int id)
        {
            InsumoGestionCultivo? insumoGestionCultivo = await _db.InsumoGestionCultivos.FindAsync(id);
            if (insumoGestionCultivo == null) return insumoGestionCultivo;
            insumoGestionCultivo.IsActive = false;
            _db.Entry(insumoGestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return insumoGestionCultivo;
        }
    }
}
