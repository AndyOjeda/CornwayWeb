using CornwayWeb.Model;
using CornwayWeb.Repositories;

namespace CornwayWeb.Services
{
    public interface ICultivoService
    {
        Task<IEnumerable<Cultivo>> GetCultivos();
        Task<Cultivo?> GetCultivo(int id);
        Task<Cultivo> CreateCultivo(
            int IdUsuario,
            int IdTipoCultivo,
            string Nombre,
            string Area
            );
        Task<Cultivo> PutCultivo(
            int IdCultivo,
            int? IdUsuario,
            int? IdTipoCultivo,
            string? Nombre,
            string? Area
            );
        Task<Cultivo?> DeleteCultivo(int id);
    }
    public class CultivoService(ICultivoRepository cultivoRepository) : ICultivoService
    {
        public async Task<Cultivo?> GetCultivo(int id)
        {
            return await cultivoRepository.GetCultivo(id);
        }

        public async Task<IEnumerable<Cultivo>> GetCultivos()
        {
            return await cultivoRepository.GetCultivos();
        }

        public async Task<Cultivo> CreateCultivo(
            int IdUsuario,
            int IdTipoCultivo,
            string Nombre,
            string Area
            )
        {
            return await cultivoRepository.CreateCultivo(new Cultivo
            {
                IdUsuario = IdUsuario,
                IdTipoCultivo = IdTipoCultivo,
                Nombre = Nombre,
                Area = Area
            });
        }

        public async Task<Cultivo> PutCultivo(
            int IdCultivo,
            int? IdUsuario,
            int? IdTipoCultivo,
            string? Nombre,
            string? Area
                       )
        {
            Cultivo? cultivo = await cultivoRepository.GetCultivo(IdCultivo);
            if (cultivo == null) throw new Exception("Cultivo no encontrado");

            cultivo.IdUsuario = IdUsuario ?? cultivo.IdUsuario;
            cultivo.IdTipoCultivo = IdTipoCultivo ?? cultivo.IdTipoCultivo;
            cultivo.Nombre = Nombre ?? cultivo.Nombre;
            cultivo.Area = Area ?? cultivo.Area;
            return await cultivoRepository.PutCultivo(cultivo);
        }

        public async Task<Cultivo?> DeleteCultivo(int id)
        {
            return await cultivoRepository.DeleteCultivo(id);
        }
    }
}
