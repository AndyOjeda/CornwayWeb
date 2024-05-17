using CornwayWeb.Model;
using CornwayWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cosecha> Cosechas { get; set; }
        public DbSet<Cultivo> Cultivos { get; set; }
        public DbSet<GestionCultivo> GestionCultivos { get; set; }
        public DbSet<InsumoCultivo> InsumoCultivos { get; set; }
        public DbSet<InsumoGestionCultivo> InsumoGestionCultivos { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<TipoCultivo> TipoCultivos { get; set; }
        public DbSet<TipoGestionCultivo> TipoGestionCultivos { get; set; }
        public DbSet<TipoInsumoGestionCultivo> TipoInsumoGestionCultivos { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cosecha>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<Cultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<GestionCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<InsumoCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<InsumoGestionCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<Partida>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<TipoCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<TipoGestionCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<TipoInsumoGestionCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<TipoUsuario>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<Usuario>().HasQueryFilter(e => e.IsActive);

        }
    }
}
