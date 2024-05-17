using CornwayWeb.Model;
using CornwayWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CornwayWeb.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cosecha> Cosechas { get; set; }
        public DbSet<Cultivos> Cultivos { get; set; }
        public DbSet<GestionesCultivo> GestionesCultivos { get; set; }
        public DbSet<InsumoCultivo> InsumoCultivos { get; set; }
        public DbSet<InsumosGestionCultivo> InsumosGestionCultivos { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<TiposCultivo> TiposCultivo { get; set; }
        public DbSet<TiposGestionCultivo> TiposGestionCultivos { get; set; }
        public DbSet<TiposInsumoGestionCultivo> TiposInsumoGestionCultivos { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }


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
            modelBuilder.Entity<Cultivos>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<GestionesCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<InsumoCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<InsumosGestionCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<Partida>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<TiposCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<TiposGestionCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<TiposInsumoGestionCultivo>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<TipoUsuario>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<Usuarios>().HasQueryFilter(e => e.IsActive);

        }
    }
}
