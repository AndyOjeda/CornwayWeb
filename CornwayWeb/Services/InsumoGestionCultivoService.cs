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
    public class InsumoGestionCultivoService(InsumoGestionCultivoRepository insumoGestionCultivoRepository) : IInsumoGestionCultivoService
    {
        
    }

}
