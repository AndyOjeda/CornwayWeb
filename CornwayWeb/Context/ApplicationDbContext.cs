using CornwayWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoGestionCultivo> TipoGestionCultivos { get; set; }
        public DbSet<TipoInsumoGestionCultivo> TipoInsumoGestionCultivos { get; set; }
        public DbSet<TipoCultivo> TipoCultivos { get; set; }
    }
}
