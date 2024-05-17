using CornwayWeb.Context;
using CornwayWeb.Model;
using CornwayWeb.Repositories;

namespace CornwayWeb.Services
{
    public interface ICosechaService
    {
        Task<IEnumerable<Cosecha>> GetCosechas();
        Task<Cosecha?> GetCosecha(int id);
        Task<Cosecha> CreateCosecha(
            int IdCultivo,
            int Cantidad,
            string Fecha
            );
        Task<Cosecha> PutCosecha(
            int IdCosecha,
            int? IdCultivo,
            int? Cantidad,
            string? Fecha
            );
        Task<Cosecha?> DeleteCosecha(int id);
    }
    public class CosechaService(ICosechaRepository cosechaRepository) : ICosechaService
    {
        public async Task<Cosecha?> GetCosecha(int id)
        {
            return await cosechaRepository.GetCosecha(id);
        }
        public async Task<IEnumerable<Cosecha>> GetCosechas()
        {
            return await cosechaRepository.GetCosechas();
        }

        public async Task<Cosecha> CreateCosecha(
             int IdCultivo,
             int Cantidad,
             string Fecha
             )
        {
            return await cosechaRepository.CreateCosecha(new Cosecha
            {
                IdCultivo = IdCultivo,
                Cantidad = Cantidad,
                Fecha = Fecha
            });
        }

        public async Task<Cosecha> PutCosecha(
            int IdCosecha,
            int? IdCultivo,
            int? Cantidad,
            string? Fecha
            )
        {
            Cosecha? cosecha = await cosechaRepository.GetCosecha(IdCosecha);
            if (cosecha == null) throw new Exception("Cosecha no encontrada");

            cosecha.IdCultivo = IdCultivo ?? cosecha.IdCultivo;
            cosecha.Cantidad = Cantidad ?? cosecha.Cantidad;
            cosecha.Fecha = Fecha ?? cosecha.Fecha;
            return await cosechaRepository.PutCosecha(cosecha);
        }

        public async Task<Cosecha?> DeleteCosecha(int id)
        {
            return await cosechaRepository.DeleteCosecha(id);
        }
    }
}
