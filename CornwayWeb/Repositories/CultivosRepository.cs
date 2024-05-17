using CornwayWeb.Model;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface ICultivosRepository
    {
        Task<IEnumerable<Cultivos>> GetCultivos();
        Task<Cultivos?> GetCultivo(int id);
        Task<Cultivos> CreateCultivo(Cultivos cultivo);
        Task<Cultivos> PutCultivo(Cultivos cultivo);
        Task<Cultivos?> DeleteCultivo(int id);
    }
    public class CultivosRepository : ICultivosRepository
    {
        private readonly ApplicationDbContext _db;
        public CultivosRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Cultivos?> GetCultivo(int id)
        {
            return await _db.Cultivos.FindAsync(id);
        }
        public async Task<IEnumerable<Cultivos>> GetCultivos()
        {
            return await _db.Cultivos.ToListAsync();
        }
        public async Task<Cultivos> CreateCultivo(Cultivos cultivo)
        {
            _db.Cultivos.Add(cultivo);
            await _db.SaveChangesAsync();
            return cultivo;
        }
        public async Task<Cultivos> PutCultivo(Cultivos cultivo)
        {
            _db.Entry(cultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return cultivo;
        }
        public async Task<Cultivos?> DeleteCultivo(int id)
        {
            Cultivos? cultivo = await _db.Cultivos.FindAsync(id);
            if (cultivo == null) return cultivo;
            cultivo.IsActive = false;
            _db.Entry(cultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return cultivo;
        }
    }
}
