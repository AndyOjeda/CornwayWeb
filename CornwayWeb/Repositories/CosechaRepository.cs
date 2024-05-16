using CornwayWeb.Model;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface ICosechaRepository
    {
        Task<IEnumerable<Cosecha>> GetCosechas();
        Task<Cosecha?> GetCosecha(int id);
        Task<Cosecha> CreateCosecha(Cosecha cosecha);
        Task<Cosecha> PutCosecha (Cosecha cosecha);
        Task<Cosecha?> DeleteCosecha (int id);
    }
    public class CosechaRepository : ICosechaRepository
    {
        private readonly ApplicationDbContext _db;
        public CosechaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Cosecha?> GetCosecha(int id)
        {
            return await _db.Cosechas.FindAsync(id);
        }
        public async Task<IEnumerable<Cosecha>> GetCosechas()
        {
            return await _db.Cosechas.ToListAsync();
        }
        public async Task<Cosecha> CreateCosecha(Cosecha cosecha)
        {
            _db.Cosechas.Add(cosecha);
            await _db.SaveChangesAsync();
            return cosecha;
        }
        public async Task<Cosecha> PutCosecha(Cosecha cosecha)
        {
            _db.Entry(cosecha).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return cosecha;
        }
        public async Task<Cosecha?> DeleteCosecha(int id)
        {
            Cosecha? cosecha = await _db.Cosechas.FindAsync(id);
            if (cosecha == null) return cosecha;
            cosecha.IsActive = false;
            _db.Entry(cosecha).State =EntityState.Modified;
            await _db.SaveChangesAsync();
            return cosecha;
        }
    }
}
