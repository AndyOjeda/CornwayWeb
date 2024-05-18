using CornwayWeb.Model;
using CornwayWeb.Repositories;


namespace CornwayWeb.Services
{
    public interface IGestionesCultivoService
    {
        Task<IEnumerable<GestionesCultivo>> GetGestionesCultivo();
        Task<GestionesCultivo?> GetGestionesCultivo(int id);
        Task<GestionesCultivo> CreateGestionesCultivo(
            int IdCultivo,
            int IdTipoGestionCultivo,
            int IdInsumoGestionCultivo,
            DateOnly FechaGestion,
            string Comentario
                       );
        Task<GestionesCultivo> PutGestionesCultivo(
            int IdGestionCultivo,
            int IdCultivo,
            int IdTipoGestionCultivo,
            int IdInsumoGestionCultivo,
            DateOnly FechaGestion,
            string Comentario
                       );
        Task<GestionesCultivo?> DeleteGestionesCultivo(int id);
    }
    public class GestionesCultivoService(IGestionesCultivoRepository gestionesCultivoRepository) : IGestionesCultivoService
    {
        public async Task<GestionesCultivo?> GetGestionesCultivo(int id)
        {
            return await gestionesCultivoRepository.GetGestionesCultivo(id);
        }

        public async Task<IEnumerable<GestionesCultivo>> GetGestionesCultivo()
        {
            return await gestionesCultivoRepository.GetGestionesCultivo();
        }

        public async Task<GestionesCultivo> CreateGestionesCultivo(
                       int IdCultivo,
                                  int IdTipoGestionCultivo,
                                  int IdInsumoGestionCultivo,
                                             DateOnly FechaGestion,
                                                        string Comentario
                                  )
        {
            return await gestionesCultivoRepository.CreateGestionesCultivo(new GestionesCultivo
            {
                IdCultivo = IdCultivo,
                IdTipoGestionCultivo = IdTipoGestionCultivo,
                IdInsumoGestionCultivo = IdInsumoGestionCultivo,
                FechaGestion = FechaGestion,
                Comentario = Comentario
            });
        }

        public async Task<GestionesCultivo> PutGestionesCultivo(
                       int IdGestionCultivo,
                                  int IdCultivo,
                                             int IdTipoGestionCultivo,
                                             int IdInsumoGestionCultivo,
                                                        DateOnly FechaGestion,
                                                                   string Comentario
                                  )
        {
            GestionesCultivo? gestionesCultivo = await gestionesCultivoRepository.GetGestionesCultivo(IdGestionCultivo);
            if (gestionesCultivo == null) throw new Exception("Gestion de cultivo no encontrada");

            gestionesCultivo.IdCultivo = IdCultivo;
            gestionesCultivo.IdTipoGestionCultivo = IdTipoGestionCultivo;
            gestionesCultivo.IdInsumoGestionCultivo = IdInsumoGestionCultivo;
            gestionesCultivo.FechaGestion = FechaGestion;
            gestionesCultivo.Comentario = Comentario;
            return await gestionesCultivoRepository.PutGestionesCultivo(gestionesCultivo);
        }

        public async Task<GestionesCultivo?> DeleteGestionesCultivo(int id)
        {
            return await gestionesCultivoRepository.DeleteGestionesCultivo(id);
        }
    }
    
}
