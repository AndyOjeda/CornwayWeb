using CornwayWeb.Context;
using CornwayWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface IGestionCultivoRepository
    {
        Task<IEnumerable<GestionCultivo>> GetGestionCultivos();
        Task<GestionCultivo?> GetGestionCultivo(int id);
        Task<GestionCultivo> CreateGestionCultivo(GestionCultivo gestionCultivo);
        Task<GestionCultivo> PutGestionCultivo(GestionCultivo gestionCultivo);
        Task<GestionCultivo?> DeleteGestionCultivo(int id);
    }
    public class GestionCultivoRepository : IGestionCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public GestionCultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async  Task<GestionCultivo?> GetGestionCultivo(int id)
        {
            return await _db.GestionCultivos.FindAsync(id);
        }

        public async Task<IEnumerable<GestionCultivo>> GetGestionCultivos()
        {
            return await _db.GestionCultivos.ToListAsync();
        }

        public async Task<GestionCultivo> CreateGestionCultivo(GestionCultivo gestionCultivo)
        {
            _db.GestionCultivos.Add(gestionCultivo);
            await _db.SaveChangesAsync();
            return gestionCultivo;
        }

        public async Task<GestionCultivo> PutGestionCultivo(GestionCultivo gestionCultivo)
        {
            _db.Entry(gestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return gestionCultivo;
        }

        public async Task<GestionCultivo?> DeleteGestionCultivo(int id)
        {
            GestionCultivo? gestionCultivo = await _db.GestionCultivos.FindAsync(id);
            if (gestionCultivo == null) return gestionCultivo;
            gestionCultivo.IsActive = false;
            _db.Entry(gestionCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return gestionCultivo;
        }

    }
}
