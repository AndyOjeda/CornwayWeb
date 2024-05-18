using CornwayWeb.Model;
using CornwayWeb.Repositories;


namespace CornwayWeb.Services
{
    public interface ITiposCultivoService
    {
        Task<IEnumerable<TiposCultivo>> GetTiposCultivos();
        Task<TiposCultivo?> GetTiposCultivo(int id);
        Task<TiposCultivo> CreateTiposCultivo(
                       string Nombre
                       );
        Task<TiposCultivo> PutTiposCultivo(
                       int IdTipoCultivo,
                                  string? Nombre
                       );
        Task<TiposCultivo?> DeleteTiposCultivo(int id);
    }
    public class TiposCultivoService(ITiposCultivoRepository tiposCultivoRepository) : ITiposCultivoService
    {
        public async Task<TiposCultivo?> GetTiposCultivo(int id)
        {
            return await tiposCultivoRepository.GetTiposCultivo(id);
        }

        public async Task<IEnumerable<TiposCultivo>> GetTiposCultivos()
        {
            return await tiposCultivoRepository.GetTiposCultivos();
        }

        public async Task<TiposCultivo> CreateTiposCultivo(
            string Nombre
                                   )
        {
            return await tiposCultivoRepository.CreateTiposCultivo(new TiposCultivo
            {
                Nombre = Nombre
            });
        }

        public async Task<TiposCultivo> PutTiposCultivo(
            int IdTipoCultivo,
            string? Nombre
                                  )
        {
            TiposCultivo? tiposCultivo = await tiposCultivoRepository.GetTiposCultivo(IdTipoCultivo);
            if (tiposCultivo == null) throw new Exception("Tipo de cultivo no encontrado");

            tiposCultivo.Nombre = Nombre ?? tiposCultivo.Nombre;
            return await tiposCultivoRepository.PutTiposCultivo(tiposCultivo);
        }

        public async Task<TiposCultivo?> DeleteTiposCultivo(int id)
        {
            return await tiposCultivoRepository.DeleteTiposCultivo(id);
        }
    }
    
}
