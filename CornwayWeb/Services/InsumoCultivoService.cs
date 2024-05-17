using CornwayWeb.Model;
using CornwayWeb.Models;
using CornwayWeb.Repositories;


namespace CornwayWeb.Services
{
    public interface IInsumoCultivoService
    {
        Task<IEnumerable<InsumoCultivo>> GetInsumoCultivos();
        Task<InsumoCultivo?> GetInsumoCultivo(int id);
        Task<InsumoCultivo> CreateInsumoCultivo(

            int IdTipoInsumoGestionCultivo,
            int Cantidad
            );
        Task<InsumoCultivo> PutInsumoCultivo(
            int IdInsumoCultivo,
            int? IdTipoInsumoGestionCultivo,
            int? Cantidad
            );
        Task<InsumoCultivo?> DeleteInsumoCultivo(int id);
    }
    public class InsumoCultivoService(InsumoCultivoRepository insumoCultivoRepository) : IInsumoCultivoService
    {
        public async Task<InsumoCultivo?> GetInsumoCultivo(int id)
        {
            return await insumoCultivoRepository.GetInsumoCultivo(id);
        }

        public async Task<IEnumerable<InsumoCultivo>> GetInsumoCultivos()
        {
            return await insumoCultivoRepository.GetInsumoCultivos();
        }

        public async Task<InsumoCultivo> CreateInsumoCultivo(
            int IdTipoInsumoGestionCultivo,
            int Cantidad
            )
        {
            return await insumoCultivoRepository.CreateInsumoCultivo(new InsumoCultivo
            {
                IdTipoInsumoGestionCultivo = IdTipoInsumoGestionCultivo,
                Cantidad = Cantidad
            });
        }

        public async Task<InsumoCultivo> PutInsumoCultivo(
            int IdInsumoCultivo,
            int? IdTipoInsumoGestionCultivo,
            int? Cantidad
            )
        {
            InsumoCultivo? insumoCultivo = await insumoCultivoRepository.GetInsumoCultivo(IdInsumoCultivo);
            if(insumoCultivo == null) throw new Exception("InsumoCultivo not found");

            insumoCultivo.IdTipoInsumoGestionCultivo = IdTipoInsumoGestionCultivo ?? insumoCultivo.IdTipoInsumoGestionCultivo;
            insumoCultivo.Cantidad = Cantidad ?? insumoCultivo.Cantidad;
            return await insumoCultivoRepository.PutInsumoCultivo(insumoCultivo);
        }

        public async Task<InsumoCultivo?> DeleteInsumoCultivo(int id)
        {
            return await insumoCultivoRepository.DeleteInsumoCultivo(id);
        }
    }
}
