using CornwayWeb.Context;
using CornwayWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface IPartidaRepository
    {
        Task<IEnumerable<Partida>> GetPartidas();
        Task<Partida?> GetPartida(int id);
        Task<Partida> CreatePartida(Partida partida);
        Task<Partida> PutPartida(Partida partida);
        Task<Partida?> DeletePartida(int id);
    }
    public class PartidaRepository : IPartidaRepository
    {
        private readonly ApplicationDbContext _db;

        public PartidaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async  Task<Partida?> GetPartida(int id)
        {
            return await _db.Partidas.FindAsync(id);
        }

        public async Task<IEnumerable<Partida>> GetPartidas()
        {
            return await _db.Partidas.ToListAsync();
        }

        public async Task<Partida> CreatePartida(Partida partida)
        {
            _db.Partidas.Add(partida);
            await _db.SaveChangesAsync();
            return partida;
        }

        public async Task<Partida> PutPartida(Partida partida)
        {
            _db.Entry(partida).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return partida;
        }

        public async Task<Partida?> DeletePartida(int id)
        {
            Partida? partida = await _db.Partidas.FindAsync(id);
            if (partida == null) return partida;
            partida.IsActive = false;
            _db.Entry(partida).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return partida;
        }
    }
}
