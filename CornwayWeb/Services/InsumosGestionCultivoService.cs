using CornwayWeb.Model;
using CornwayWeb.Repositories;

namespace CornwayWeb.Services
{
    public interface IInsumosGestionCultivoService
    {
        Task<IEnumerable<InsumosGestionCultivo>> GetInsumosGestionCultivos();
        Task<InsumosGestionCultivo?> GetInsumoGestionCultivo(int id);
        Task<InsumosGestionCultivo> CreateInsumoGestionCultivo(
            int IdInsumoCultivo,
            string Nombre,
            double Dosis,
            string Unidad
                       );
        Task<InsumosGestionCultivo> PutInsumoGestionCultivo(
            int IdInsumoGestionCultivo,
            int? IdInsumoCultivo,
            string? Nombre,
            double? Dosis,
            string? Unidad
                       );
        Task<InsumosGestionCultivo?> DeleteInsumoGestionCultivo(int id);
    }
    public class InsumosGestionCultivoService(IInsumosGestionCultivoRepository insumosGestionCultivoRepository) : IInsumosGestionCultivoService
    {
        public async Task<InsumosGestionCultivo?> GetInsumoGestionCultivo(int id)
        {
            return await insumosGestionCultivoRepository.GetInsumosGestionCultivo(id);
        }

        public async Task<IEnumerable<InsumosGestionCultivo>> GetInsumosGestionCultivos()
        {
            return await insumosGestionCultivoRepository.GetInsumosGestionCultivos();
        }

        public async Task<InsumosGestionCultivo> CreateInsumoGestionCultivo(
                                  int IdInsumoCultivo,
                                             string Nombre,
                                                        double Dosis,
                                                                   string Unidad
                                  )
        {
            return await insumosGestionCultivoRepository.CreateInsumosGestionCultivo(new InsumosGestionCultivo
            {
                IdInsumoCultivo = IdInsumoCultivo,
                Nombre = Nombre,
                Dosis = Dosis,
                Unidad = Unidad
            });
        }

        public async Task<InsumosGestionCultivo> PutInsumoGestionCultivo(
                       int IdInsumoGestionCultivo,
                                             int? IdInsumoCultivo,
                                                        string? Nombre,
                                                                   double? Dosis,
                                                                              string? Unidad
                                  )
        {
            InsumosGestionCultivo? insumosGestionCultivo = await insumosGestionCultivoRepository.GetInsumosGestionCultivo(IdInsumoGestionCultivo);
            if (insumosGestionCultivo == null) throw new Exception("Insumo de gestion de cultivo no encontrado");

            insumosGestionCultivo.IdInsumoCultivo = IdInsumoCultivo ?? insumosGestionCultivo.IdInsumoCultivo;
            insumosGestionCultivo.Nombre = Nombre ?? insumosGestionCultivo.Nombre;
            insumosGestionCultivo.Dosis = Dosis ?? insumosGestionCultivo.Dosis;
            insumosGestionCultivo.Unidad = Unidad ?? insumosGestionCultivo.Unidad;
            return await insumosGestionCultivoRepository.PutInsumosGestionCultivo(insumosGestionCultivo);
        }

        public async Task<InsumosGestionCultivo?> DeleteInsumoGestionCultivo(int id)
        {
            return await insumosGestionCultivoRepository.DeleteInsumosGestionCultivo(id);
        }
    }
    
}
