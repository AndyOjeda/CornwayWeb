using CornwayWeb.Repositories;
using CornwayWeb.Model;

namespace CornwayWeb.Services
{
    public interface ITipoInsumoGestionCultivoService
    {
        Task<IEnumerable<TipoInsumoGestionCultivo>> GetTipoInsumoGestionCultivos();
        Task<TipoInsumoGestionCultivo?> GetTipoInsumoGestionCultivo(int id);
        Task<TipoInsumoGestionCultivo> CreateTipoInsumoGestionCultivo(
                       string Nombre
                       );
        Task<TipoInsumoGestionCultivo> PutTipoInsumoGestionCultivo(
            
                       int IdTipoInsumoGestionCultivo,
                                  string? Nombre
                       );
        Task<TipoInsumoGestionCultivo?> DeleteTipoInsumoGestionCultivo(int id);
    }
    public class TipoInsumoGestionCultivoService(ITipoInsumoGestionCultivoRepository tipoInsumoGestionCultivoRepository) : ITipoInsumoGestionCultivoService
    {
        public async Task<TipoInsumoGestionCultivo?> GetTipoInsumoGestionCultivo(int id)
        {
            return await tipoInsumoGestionCultivoRepository.GetTipoInsumoGestionCultivo(id);
        }

        public async Task<IEnumerable<TipoInsumoGestionCultivo>> GetTipoInsumoGestionCultivos()
        {
            return await tipoInsumoGestionCultivoRepository.GetTipoInsumoGestionCultivos();
        }

        public async Task<TipoInsumoGestionCultivo> CreateTipoInsumoGestionCultivo(
                                  string Nombre
                                  )
        {
            return await tipoInsumoGestionCultivoRepository.CreateTipoInsumoGestionCultivo(new TipoInsumoGestionCultivo
            {
                Nombre = Nombre
            });
        }

        public async Task<TipoInsumoGestionCultivo> PutTipoInsumoGestionCultivo(
                       
                                  int IdTipoInsumoGestionCultivo,
                                                                   string? Nombre
                                  )
        {
            TipoInsumoGestionCultivo? tipoInsumoGestionCultivo = await tipoInsumoGestionCultivoRepository.GetTipoInsumoGestionCultivo(IdTipoInsumoGestionCultivo);
            if (tipoInsumoGestionCultivo == null) throw new Exception("TipoInsumoGestionCultivo not found");

            tipoInsumoGestionCultivo.Nombre = Nombre ?? tipoInsumoGestionCultivo.Nombre;
            return await tipoInsumoGestionCultivoRepository.PutTipoInsumoGestionCultivo(tipoInsumoGestionCultivo);
        }

        public async Task<TipoInsumoGestionCultivo?> DeleteTipoInsumoGestionCultivo(int id)
        {
            return await tipoInsumoGestionCultivoRepository.DeleteTipoInsumoGestionCultivo(id);
        }
    }
    
}
