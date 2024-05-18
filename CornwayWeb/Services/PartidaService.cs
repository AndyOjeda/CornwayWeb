using CornwayWeb.Repositories;
using CornwayWeb.Model;

namespace CornwayWeb.Services
{
    public interface IPartidaService
    {
        Task<IEnumerable<Partida>> GetPartidas();
        Task<Partida?> GetPartida(int id);
        Task<Partida> CreatePartida(
            int IdCosecha,
            int Monedas
            );
        Task<Partida> PutPartida(
            int IdPartida,
            int? IdCosecha,
            int? Monedas
            );
        Task<Partida?> DeletePartida(int id);
    }
    public class PartidaService(IPartidaRepository partidaRepository) : IPartidaService
    {
        public async Task<Partida?> GetPartida(int id)
        {
            return await partidaRepository.GetPartida(id);
        }

        public async Task<IEnumerable<Partida>> GetPartidas()
        {
            return await partidaRepository.GetPartidas();
        }

        public async Task<Partida> CreatePartida(
            int IdCosecha,
            int Monedas
            )
        {
            return await partidaRepository.CreatePartida(new Partida
            {
                IdCosecha = IdCosecha,
                Monedas = Monedas
            });
        }

        public async Task<Partida> PutPartida(
            int IdPartida,
            int? IdCosecha,
            int? Monedas
                       )
        {
            Partida? partida = await partidaRepository.GetPartida(IdPartida);
            if(partida == null) throw new Exception("Partida not found");

            partida.IdCosecha = IdCosecha ?? partida.IdCosecha;
            return await partidaRepository.PutPartida(partida);
        }

        public async Task<Partida?> DeletePartida(int id)
        {
            return await partidaRepository.DeletePartida(id);
        }
    }
    
}
