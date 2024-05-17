using CornwayWeb.Repositories;
using CornwayWeb.Model;

namespace CornwayWeb.Services
{
    public interface ITipoCultivoService
    {
        Task<IEnumerable<TipoCultivo>> GetTipoCultivos();
        Task<TipoCultivo?> GetTipoCultivo(int id);
        Task<TipoCultivo> CreateTipoCultivo(
            string Nombre
            );
        Task<TipoCultivo> PutTipoCultivo(

            int IdTipoCultivo,
            string? Nombre
            );
        Task<TipoCultivo?> DeleteTipoCultivo(int id);
    }
    public class TipoCultivoService(ITipoCultivoRepository tipoCultivoRepository) : ITipoCultivoService
    {
        public async Task<TipoCultivo?> GetTipoCultivo(int id)
        {
            return await tipoCultivoRepository.GetTipoCultivo(id);
        }

        public async Task<IEnumerable<TipoCultivo>> GetTipoCultivos()
        {
            return await tipoCultivoRepository.GetTipoCultivos();
        }

        public async Task<TipoCultivo> CreateTipoCultivo(
            string Nombre
            )
        {
            return await tipoCultivoRepository.CreateTipoCultivo(new TipoCultivo
            {
                Nombre = Nombre
            });
        }

        public async Task<TipoCultivo> PutTipoCultivo(
            int IdTipoCultivo,
            string? Nombre
            )
        {
            TipoCultivo? tipoCultivo = await tipoCultivoRepository.GetTipoCultivo(IdTipoCultivo);
            if (tipoCultivo == null) throw new Exception("TipoCultivo not found");

            tipoCultivo.Nombre = Nombre ?? tipoCultivo.Nombre;
            return await tipoCultivoRepository.PutTipoCultivo(tipoCultivo);
        }

        public async Task<TipoCultivo?> DeleteTipoCultivo(int id)
        {
            return await tipoCultivoRepository.DeleteTipoCultivo(id);
        }
    }

}
