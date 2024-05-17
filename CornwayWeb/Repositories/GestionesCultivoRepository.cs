using CornwayWeb.Model;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface IGestionesCultivoRepository
    {
        Task<IEnumerable<GestionesCultivo>> GetGestionesCultivo();
        Task<GestionesCultivo?> GetGestionesCultivo(int id);
        Task<GestionesCultivo> CreateGestionesCultivo(GestionesCultivo gestionesCultivo);
        Task<GestionesCultivo> PutGestionesCultivo(GestionesCultivo gestionesCultivo);
        Task<GestionesCultivo?> DeleteGestionesCultivo(int id);
    }
    public class GestionesCultivoRepository : IGestionesCultivoRepository
    {
        private readonly ApplicationDbContext _db;

        public GestionesCultivoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<GestionesCultivo?> GetGestionesCultivo(int id)
        {
            return await _db.GestionesCultivos.FindAsync(id);
        }

        public async Task<IEnumerable<GestionesCultivo>> GetGestionesCultivo()
        {
            return await _db.GestionesCultivos.ToListAsync();
        }

        public async Task<GestionesCultivo> CreateGestionesCultivo(GestionesCultivo gestionesCultivo)
        {
            _db.GestionesCultivos.Add(gestionesCultivo);
            await _db.SaveChangesAsync();
            return gestionesCultivo;
        }

        public async Task<GestionesCultivo> PutGestionesCultivo(GestionesCultivo gestionesCultivo)
        {
            _db.Entry(gestionesCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return gestionesCultivo;
        }

        public async Task<GestionesCultivo?> DeleteGestionesCultivo(int id)
        {
            GestionesCultivo? gestionesCultivo = await _db.GestionesCultivos.FindAsync(id);
            if (gestionesCultivo == null) return gestionesCultivo;
            gestionesCultivo.IsActive = false;
            _db.Entry(gestionesCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return gestionesCultivo;
        }
    }
    
}
