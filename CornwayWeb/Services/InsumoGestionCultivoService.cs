using CornwayWeb.Repositories;
using CornwayWeb.Models;
using CornwayWeb.Model;

namespace CornwayWeb.Services
{
    public interface IInsumoGestionCultivoService
    {
        Task<IEnumerable<InsumoGestionCultivo>> GetInsumoGestionCultivos();
        Task<InsumoGestionCultivo?> GetInsumoGestionCultivo(int id);
        Task<InsumoGestionCultivo> CreateInsumoGestionCultivo(

            int IdGestionCultivo,
            int IdTipoInsumoGestionCultivo,
            string Nombre,
            string Dosis,
            string Unidad
            );
        Task<InsumoGestionCultivo> PutInsumoGestionCultivo(
            int IdInsumoGestionCultivo,
            int? IdGestionCultivo,
            int? IdTipoInsumoGestionCultivo,
            string? Nombre,
            string? Dosis,
            string? Unidad
            );
        Task<InsumoGestionCultivo?> DeleteInsumoGestionCultivo(int id);

    }
    public class InsumoGestionCultivoService(IInsumoGestionCultivoRepository insumoGestionCultivoRepository) : IInsumoGestionCultivoService
    {
        public async Task<InsumoGestionCultivo?> GetInsumoGestionCultivo(int id)
        {
            return await insumoGestionCultivoRepository.GetInsumoGestionCultivo(id);
        }

        public async Task<IEnumerable<InsumoGestionCultivo>> GetInsumoGestionCultivos()
        {
            return await insumoGestionCultivoRepository.GetInsumoGestionCultivos();
        }

        public async Task<InsumoGestionCultivo> CreateInsumoGestionCultivo(
            int IdGestionCultivo,
            int IdTipoInsumoGestionCultivo,
            string Nombre,
            string Dosis,
            string Unidad
                       )
        {
            return await insumoGestionCultivoRepository.CreateInsumoGestionCultivo(new InsumoGestionCultivo
            {
                IdGestionCultivo = IdGestionCultivo,
                IdTipoInsumoGestionCultivo = IdTipoInsumoGestionCultivo,
                Nombre = Nombre,
                Dosis = Dosis,
                Unidad = Unidad
            });
        }

        public async Task<InsumoGestionCultivo> PutInsumoGestionCultivo(

            int IdInsumoGestionCultivo,
            int? IdGestionCultivo,
            int? IdTipoInsumoGestionCultivo,
            string? Nombre,
            string? Dosis,
            string? Unidad
            )
        {
            InsumoGestionCultivo? insumoGestionCultivo = await insumoGestionCultivoRepository.GetInsumoGestionCultivo(IdInsumoGestionCultivo);
            if(insumoGestionCultivo == null) throw new Exception("InsumoGestionCultivo not found");

            insumoGestionCultivo.IdGestionCultivo = IdGestionCultivo ?? insumoGestionCultivo.IdGestionCultivo;
            insumoGestionCultivo.IdTipoInsumoGestionCultivo = IdTipoInsumoGestionCultivo ?? insumoGestionCultivo.IdTipoInsumoGestionCultivo;
            insumoGestionCultivo.Nombre = Nombre ?? insumoGestionCultivo.Nombre;
            insumoGestionCultivo.Dosis = Dosis ?? insumoGestionCultivo.Dosis;
            insumoGestionCultivo.Unidad = Unidad ?? insumoGestionCultivo.Unidad;
            return await insumoGestionCultivoRepository.PutInsumoGestionCultivo(insumoGestionCultivo);
        }

        public async Task<InsumoGestionCultivo?> DeleteInsumoGestionCultivo(int id)
        {
            return await insumoGestionCultivoRepository.DeleteInsumoGestionCultivo(id);
        }
    }

}
