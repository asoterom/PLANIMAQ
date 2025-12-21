using Microsoft.EntityFrameworkCore;
using Planimaq.Shared.Entities;

namespace Planimaq.backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 

        }

        
        public DbSet<Configuracion> Configuraciones { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Maestro> Maestros { get; set; }
        public DbSet<Personal> Personales { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Configuracion>().HasIndex(c => c.Name).IsUnique();



            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c => new { c.stateId, c.Name }).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex(c => new {c.CountryId,c.Name } ).IsUnique();
            
            DisableCascadingDelete(modelBuilder);

        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()); 
            foreach (var relationship in relationships) { 
                relationship.DeleteBehavior = DeleteBehavior.Restrict; 
            }
        }
    }
}