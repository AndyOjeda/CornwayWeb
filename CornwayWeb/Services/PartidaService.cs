using CornwayWeb.Repositories;
using CornwayWeb.Model;

namespace CornwayWeb.Services
{
    public interface IPartidaService
    {
        Task<IEnumerable<Partida>> GetPartidas();
        Task<Partida?> GetPartida(int id);
        Task<Partida> CreatePartida(
            int IdCosecha
            );
        Task<Partida> PutPartida(
            int IdPartida,
            int? IdCosecha
            );
    }
    public class PartidaService(PartidaRepository partidaRepository) : IPartidaService
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
            int IdCosecha
            )
        {
            return await partidaRepository.CreatePartida(new Partida
            {
                IdCosecha = IdCosecha
            });
        }

        public async Task<Partida> PutPartida(
            int IdPartida,
            int? IdCosecha
                       )
        {
            Partida? partida = await partidaRepository.GetPartida(IdPartida);
            if(partida == null) throw new Exception("Partida not found");

            partida.IdCosecha = IdCosecha ?? partida.IdCosecha;
            return await partidaRepository.PutPartida(partida);
        }
    }
    {
    }
}
