
using Microsoft.EntityFrameworkCore;
using Planimaq.Shared.Entities;

namespace Planimaq.backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            //await CheckCountriesFullAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
        }

        private async Task CheckCountriesFullAsync()
        {
            if (!_context.Countries.Any())
            {
                var CountriesSQLScript = File.ReadAllText("Data\\CountriesStatesCities.sql");
                await _context.Database.ExecuteSqlRawAsync(CountriesSQLScript);
            }
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name ="Calzado" });
                _context.Categories.Add(new Category { Name = "Tecnologia" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(
                    new Country {
                        Name = "Colombia",
                        States = [ new State() { 
                            Name = "Antioquia", 
                            Cities = [ 
                                new City() { Name = "Medellín" }, 
                                new City() { Name = "Itagüí" }, 
                                new City() { Name = "Envigado" }, 
                                new City() { Name = "Bello" }, 
                                new City() { Name = "Rionegro" }, ] }, 
                            new State() { Name = "Bogotá",
                            Cities = [ 
                                new City() { Name = "Usaquen" }, 
                                new City() { Name = "Champinero" }, 
                                new City() { Name = "Santa fe" }, 
                                new City() { Name = "Useme" }, 
                                new City() { Name = "Bosa" }, 
                            ] 
                            }, 
                        ]
                    }
                    
                    );
                _context.Countries.Add(new Country { Name = "Perú" });
                await _context.SaveChangesAsync();

            }
        }
    }
}
