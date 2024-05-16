using CornwayWeb.Model;
using CornwayWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cosecha> Cosechas { get; set; }
        public DbSet<Cultivo> Cultivos { get; set; }
        public DbSet<GestionCultivo> GestionCuiltivos { get; set; }
        public DbSet<InsumoCultivo> InsumoCultivos { get; set; }
        public DbSet<InsumoGestionCultivo> InsumoGestionCultivos { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<TipoCultivo> TipoCultivos { get; set; }
        public DbSet<TipoGestionCultivo> TipoGestionCultivos { get; set; }
        public DbSet<TipoInsumoGestionCultivo> TipoInsumoGestionCultivos { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
