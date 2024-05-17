using CornwayWeb.Model;
using CornwayWeb.Repositories;

namespace CornwayWeb.Services
{
    public interface ICultivosService
    {
        Task<IEnumerable<Cultivos>> GetCultivos();
        Task<Cultivos?> GetCultivo(int id);
        Task<Cultivos> CreateCultivo(
            int IdUsuario,
            string Nombre,
            int IdTipoCultivo,
            int Area
                       );
        Task<Cultivos> PutCultivo(
            int IdCultivo,
            int? IdUsuario,
            string? Nombre,
            int? IdTipoCultivo,
            int? Area
                       );
        Task<Cultivos?> DeleteCultivo(int id);
    }
    public class CultivosService(ICultivosRepository cultivosRepository) : ICultivosService
    {
        public async Task<Cultivos?> GetCultivo(int id)
        {
            return await cultivosRepository.GetCultivo(id);
        }

        public async Task<IEnumerable<Cultivos>> GetCultivos()
        {
            return await cultivosRepository.GetCultivos();
        }

        public async Task<Cultivos> CreateCultivo(
                       int IdUsuario,
                                  string Nombre,
                                             int IdTipoCultivo,
                                                        int Area
                                  )
        {
            return await cultivosRepository.CreateCultivo(new Cultivos
            {
                IdUsuario = IdUsuario,
                Nombre = Nombre,
                IdTipoCultivo = IdTipoCultivo,
                Area = Area
            });
        }

        public async Task<Cultivos> PutCultivo(
                       int IdCultivo,
                                  int? IdUsuario,
                                             string? Nombre,
                                                        int? IdTipoCultivo,
                                                                   int? Area
                                  )
        {
            Cultivos? cultivo = await cultivosRepository.GetCultivo(IdCultivo);
            if (cultivo == null) throw new Exception("Cultivo no encontrado");

            cultivo.IdUsuario = IdUsuario ?? cultivo.IdUsuario;
            cultivo.Nombre = Nombre ?? cultivo.Nombre;
            cultivo.IdTipoCultivo = IdTipoCultivo ?? cultivo.IdTipoCultivo;
            cultivo.Area = Area ?? cultivo.Area;
            return await cultivosRepository.PutCultivo(cultivo);
        }

        public async Task<Cultivos?> DeleteCultivo(int id)
        {
            return await cultivosRepository.DeleteCultivo(id);
        }
    }
    
}
