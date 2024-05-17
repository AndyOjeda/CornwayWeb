using CornwayWeb.Model;
using CornwayWeb.Repositories;

namespace CornwayWeb.Services
{
    public interface ITiposInsumoGestionCultivoService
    {
        Task<IEnumerable<TiposInsumoGestionCultivo>> GetTipoInsumoGestionCultivos();
        Task<TiposInsumoGestionCultivo?> GetTipoInsumoGestionCultivo(int id);
        Task<TiposInsumoGestionCultivo> CreateTipoInsumoGestionCultivo(
                       string Nombre
                       );
        Task<TiposInsumoGestionCultivo> PutTipoInsumoGestionCultivo(
                       int IdTipoInsumoGestionCultivo,
                                  string? Nombre
                       );
        Task<TiposInsumoGestionCultivo?> DeleteTipoInsumoGestionCultivo(int id);
    }
    public class TiposInsumoGestionCultivoService(ITiposInsumoGestionCultivoRepository tiposInsumoGestionCultivoRepository) : ITiposInsumoGestionCultivoService
    {
        public async Task<TiposInsumoGestionCultivo?> GetTipoInsumoGestionCultivo(int id)
        {
            return await tiposInsumoGestionCultivoRepository.GetTiposInsumoGestionCultivo(id);
        }

        public async Task<IEnumerable<TiposInsumoGestionCultivo>> GetTipoInsumoGestionCultivos()
        {
            return await tiposInsumoGestionCultivoRepository.GetTiposInsumoGestionCultivos();
        }

        public async Task<TiposInsumoGestionCultivo> CreateTipoInsumoGestionCultivo(
                        string Nombre
                        )
        {
            return await tiposInsumoGestionCultivoRepository.CreateTiposInsumoGestionCultivo(new TiposInsumoGestionCultivo
            {
                Nombre = Nombre
            });
        }

        public async Task<TiposInsumoGestionCultivo> PutTipoInsumoGestionCultivo(
                       int IdTipoInsumoGestionCultivo,
                                  string? Nombre
                       )
        {
            TiposInsumoGestionCultivo? tiposInsumoGestionCultivo = await tiposInsumoGestionCultivoRepository.GetTiposInsumoGestionCultivo(IdTipoInsumoGestionCultivo);
            if (tiposInsumoGestionCultivo == null) throw new Exception("Tipo de insumo de gestion de cultivo no encontrado");

            tiposInsumoGestionCultivo.Nombre = Nombre ?? tiposInsumoGestionCultivo.Nombre;
            return await tiposInsumoGestionCultivoRepository.PutTiposInsumoGestionCultivo(tiposInsumoGestionCultivo);
        }

        public async Task<TiposInsumoGestionCultivo?> DeleteTipoInsumoGestionCultivo(int id)
        {
            return await tiposInsumoGestionCultivoRepository.DeleteTiposInsumoGestionCultivo(id);
        }
    }
    
}
