using CornwayWeb.Model;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface ICultivoRepository
    {
        Task<IEnumerable<Cultivo>> GetCultivos();
        Task<Cultivo?> GetCultivo(int id);
        Task<Cultivo> GetCultivos(Cultivo cultivo);
        Task<Cultivo> CreateCultivo(Cultivo cultivo);
        Task<Cultivo?> DeleteCultivo(int id);
    }
    public class CultivoRepository : ICultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public CultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Cultivo?> GetCultivo(int id)
        {
            return await _db.Cultivos.FindAsync(id);
        }
        public async Task<IEnumerable<Cultivo>> GetCultivos()
        {
            return await _db.Cultivos.ToListAsync();
        }
        public async Task<Cultivo> CreateCultivo(Cultivo cultivo)
        {
            _db.Cultivos.Add(cultivo);
            await _db.SaveChangesAsync();
            return cultivo;
        }
        public async Task<Cultivo> PutCultivo(Cultivo cultivo)
        {
            _db.Entry(cultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return cultivo;
        }

        public async Task<Cultivo?> DeleteCultivo(int id)
        {
            Cultivo? cultivo = await _db.Cultivos.FindAsync(id);
            if (cultivo == null) return cultivo;
            cultivo.IsActive = false;
            _db.Entry(cultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return cultivo;
        }
    }
}
