using CornwayWeb.Model;
using CornwayWeb.Repositories;

namespace CornwayWeb.Services
{
    public interface IGestionCultivoService
    {
        Task<IEnumerable<GestionCultivo>> GetGestionCultivos();
        Task<GestionCultivo?> GetGestionCultivo();
        Task<GestionCultivo> CreateGestionCultivo(
            int IdCultivo,
            int IdTipoGestionCultivo,
            DateTime Fecha,
            string comentario
            );
        Task<GestionCultivo> PutGestionCultivo(
            int IdGestionCultivo,
            int IdCultivo,
            int IdTipoGestionCultivo,
            DateTime Fecha,
            string comentario
            );
        Task<GestionCultivo?> DeleteGestionCultivo(int id);
    }
    public class GestionCultivoService(IGestionCultivoRepository gestionCultivoRepository) : IGestionCultivoService
    {
        public async Task<GestionCultivo?> GetGestionCultivo(int id)
        {
            return await gestionCultivoRepository.GetGestionCultivo(id);
        }

        public async Task<IEnumerable<GestionCultivo>> GetGestionCultivos()
        {
            return await gestionCultivoRepository.GetGestionCultivos();
        }

        public async Task<GestionCultivo> CreateGestionCultivo(
            int IdCultivo,
            int IdTipoGestionCultivo,
            DateTime Fecha,
            string comentario
            )
        {
            return await gestionCultivoRepository.CreateGestionCultivo(new GestionCultivo
            {
                IdCultivo = IdCultivo,
                IdTipoGestionCultivo = IdTipoGestionCultivo,
                Fecha = Fecha,
                Comentario = comentario
            });
        }

        public async Task<GestionCultivo> PutGestionCultivo(
            int IdGestionCultivo,
            int IdCultivo,
            int IdTipoGestionCultivo,
            DateTime Fecha,
            string comentario
            )
        {
            GestionCultivo gestionCultivo = await gestionCultivoRepository.PutGestionCultivo(IdGestionCultivo);
            if(gestionCultivo == null) throw new Exception("Gestion de cultivo no encontrada");

            gestionCultivo.IdCultivo = IdCultivo ?? gestionCultivo.IdCultivo;
            gestionCultivo.IdTipoGestionCultivo = IdTipoGestionCultivo ?? gestionCultivo.IdTipoGestionCultivo;
            gestionCultivo.Fecha = Fecha ?? gestionCultivo.Fecha;
            gestionCultivo.Comentario = comentario ?? gestionCultivo.Comentario;
            return await gestionCultivoRepository.PutGestionCultivo(gestionCultivo);
        }

        public async Task<GestionCultivo?> DeleteGestionCultivo(int id)
        {
            return await gestionCultivoRepository.DeleteGestionCultivo(id);
        }
    }
}
