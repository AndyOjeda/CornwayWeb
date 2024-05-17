using CornwayWeb.Model;
using CornwayWeb.Repositories;

namespace CornwayWeb.Services
{
    public interface ITiposGestionCultivoService
    {
        Task<IEnumerable<TiposGestionCultivo>> GetTipoGestionCultivos();
        Task<TiposGestionCultivo?> GetTipoGestionCultivo(int id);
        Task<TiposGestionCultivo> CreateTipoGestionCultivo(
            string Nombre
            );
        Task<TiposGestionCultivo> PutTipoGestionCultivo(
            int IdTipoGestionCultivo,
            string? Nombre
            );
        Task<TiposGestionCultivo?> DeleteTipoGestionCultivo(int id);
    }
    public class TiposGestionCultivoService(ITiposGestionCultivoRepository tiposGestionCultivoRepository) : ITiposGestionCultivoService
    {
        public async Task<TiposGestionCultivo?> GetTipoGestionCultivo(int id)
        {
            return await tiposGestionCultivoRepository.GetTipoGestionCultivo(id);
        }

        public async Task<IEnumerable<TiposGestionCultivo>> GetTipoGestionCultivos()
        {
            return await tiposGestionCultivoRepository.GetTipoGestionCultivos();
        }

        public async Task<TiposGestionCultivo> CreateTipoGestionCultivo(
             string Nombre
             )
        {
             return await tiposGestionCultivoRepository.CreateTipoGestionCultivo( new TiposGestionCultivo
             {
                 Nombre = Nombre
             });
        }

        public async Task<TiposGestionCultivo> PutTipoGestionCultivo(
            int IdTipoGestionCultivo,
            string? Nombre
            )
        {
            TiposGestionCultivo? tiposGestionCultivo = await tiposGestionCultivoRepository.GetTipoGestionCultivo(IdTipoGestionCultivo);
            if (tiposGestionCultivo == null) throw new Exception("Tipo de gestion de cultivo no encontrado");

            tiposGestionCultivo.Nombre = Nombre ?? tiposGestionCultivo.Nombre;
            return await tiposGestionCultivoRepository.PutTipoGestionCultivo(tiposGestionCultivo);
        }

        public async Task<TiposGestionCultivo?> DeleteTipoGestionCultivo(int id)
        {
            return await tiposGestionCultivoRepository.DeleteTipoGestionCultivo(id);
        }
    }
}
