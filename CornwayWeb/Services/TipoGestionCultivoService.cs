using CornwayWeb.Repositories;
using CornwayWeb.Model;

namespace CornwayWeb.Services
{
    public interface ITipoGestionCultivoService
    {
        Task<IEnumerable<TipoGestionCultivo>> GetTipoGestionCultivos();
        Task<TipoGestionCultivo?> GetTipoGestionCultivo(int id);
        Task<TipoGestionCultivo> CreateTipoGestionCultivo(
            string Nombre
            );
        Task<TipoGestionCultivo> PutTipoGestionCultivo(

            int IdTipoGestionCultivo,
            string? Nombre
            );
        Task<TipoGestionCultivo?> DeleteTipoGestionCultivo(int id);
    }
    public class TipoGestionCultivoService(ITipoGestionCultivoRepository tipoGestionCultivoRepository) : ITipoGestionCultivoService
    {
        public async Task<TipoGestionCultivo?> GetTipoGestionCultivo(int id)
        {
            return await tipoGestionCultivoRepository.GetTipoGestionCultivo(id);
        }

        public async Task<IEnumerable<TipoGestionCultivo>> GetTipoGestionCultivos()
        {
            return await tipoGestionCultivoRepository.GetTipoGestionCultivos();
        }

        public async Task<TipoGestionCultivo> CreateTipoGestionCultivo(
            string Nombre
            )
        {
            return await tipoGestionCultivoRepository.CreateTipoGestionCultivo(new TipoGestionCultivo
            {
                Nombre = Nombre
            });
        }

        public async Task<TipoGestionCultivo> PutTipoGestionCultivo(

            int IdTipoGestionCultivo,
            string? Nombre
            )
        {
            TipoGestionCultivo? tipoGestionCultivo = await tipoGestionCultivoRepository.GetTipoGestionCultivo(IdTipoGestionCultivo);
            if (tipoGestionCultivo == null) throw new Exception("TipoGestionCultivo not found");

            tipoGestionCultivo.Nombre = Nombre ?? tipoGestionCultivo.Nombre;
            return await tipoGestionCultivoRepository.PutTipoGestionCultivo(tipoGestionCultivo);
        }

        public async Task<TipoGestionCultivo?> DeleteTipoGestionCultivo(int id)
        {
            return await tipoGestionCultivoRepository.DeleteTipoGestionCultivo(id);
        }
    }
    
}
