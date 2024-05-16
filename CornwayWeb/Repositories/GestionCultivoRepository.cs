using CornwayWeb.Context;
using CornwayWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Repositories
{
    public interface IGestionCultivoRepository
    {
        Task<IEnumerable<GestionCultivo>> GetGestionCultivos();
        Task<GestionCultivo> GetGestionCultivo(int id);
        Task<GestionCultivo> AddGestionCultivo(GestionCultivo gestionCultivo);
        Task<GestionCultivo> UpdateGestionCultivo(GestionCultivo gestionCultivo);
        Task<GestionCultivo> PutGestionCultivo(GestionCultivo gestionCultivo);
        Task<GestionCultivo> DeleteGestionCultivo(int id);
    }
    public class GestionCultivoRepository
    {
    }
}
