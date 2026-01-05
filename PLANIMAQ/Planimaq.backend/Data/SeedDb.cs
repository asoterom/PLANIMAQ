
using Microsoft.EntityFrameworkCore;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Enums;

namespace Planimaq.backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUsersUnitOfWork _usersUnitOfWork;

        public SeedDb(DataContext context,IUsersUnitOfWork usersUnitOfWork)
        {
            _context = context;
            _usersUnitOfWork = usersUnitOfWork;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            //await CheckCountriesFullAsync();
            await CheckEmpresaAsync();
            await CheckMaestroAsync();
            await CheckConfiguracionesAsync();
            //await CheckCountriesAsync();
            await CheckCategoriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Super", "Admin", "superadmin@yopmail.com", "3223114620", UserType.Admin);

        }

        private async Task CheckEmpresaAsync()
        {
            if (!_context.Empresas.Any())
            {
                _context.Empresas.Add(new Empresa { Name = "Planimaq" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRolesAsync()
        {
            await _usersUnitOfWork.CheckRoleAsync(UserType.Admin.ToString());
            await _usersUnitOfWork.CheckRoleAsync(UserType.Tecnico.ToString());
            await _usersUnitOfWork.CheckRoleAsync(UserType.Operador.ToString());
        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, 
            string email, string phone, UserType userType)
        {
            var user = await _usersUnitOfWork.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Document = document,
                    Empresa = _context.Empresas.FirstOrDefault(),
                    UserType = userType,
                };

                await _usersUnitOfWork.AddUserAsync(user, "123456");
                await _usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckMaestroAsync()
        {
            if (!_context.Maestros.Any())
            {
                _context.Maestros.Add(new Maestro { sIdGrupo = "1", sGrupo ="Mantenimiento", Name = "Preventivo", sValor = "MP", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "1", sGrupo = "Mantenimiento", Name = "Correctivo", sValor = "MC", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "2", sGrupo = "Prioridad", Name = "Nivel 1 - Critica", sValor = "1", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "2", sGrupo = "Prioridad", Name = "Nivel 2 - Importante", sValor = "2", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "2", sGrupo = "Prioridad", Name = "Nivel 3 - Regular", sValor = "3", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "2", sGrupo = "Prioridad", Name = "Nivel 4 - Opcional", sValor = "4", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "3", sGrupo = "Falla Tipo", Name = "Hidraulica", sValor = "HID", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "3", sGrupo = "Falla Tipo", Name = "Mecanica", sValor = "MEC", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "3", sGrupo = "Falla Tipo", Name = "Transmision", sValor = "TRA", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "3", sGrupo = "Falla Tipo", Name = "Neumatica", sValor = "NEU", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "3", sGrupo = "Falla Tipo", Name = "Motor", sValor = "MOT", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "3", sGrupo = "Falla Tipo", Name = "Eléctrica", sValor = "ELE", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "4", sGrupo = "Documentos", Name = "Factura", sValor = "01", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "4", sGrupo = "Documentos", Name = "Boleta", sValor = "02", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "4", sGrupo = "Documentos", Name = "Guia", sValor = "03", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "4", sGrupo = "Documentos", Name = "Recibo", sValor = "04", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "5", sGrupo = "Moneda", Name = "Nuevo sol", sValor = "PEN", sEstado = 1 });
                _context.Maestros.Add(new Maestro { sIdGrupo = "5", sGrupo = "Moneda", Name = "Dolar", sValor = "USD", sEstado = 1 });


                await _context.SaveChangesAsync();
            }

        }


        private async Task CheckConfiguracionesAsync()
        {
            if (!_context.Configuraciones.Any())
            {
                _context.Configuraciones.Add(new Configuracion { Name = "IGV (%)",Status = "SI", MailData = "" });
                _context.Configuraciones.Add(new Configuracion { Name = "Activar Notificación de Mantenimiento Preventivo (Tareas)", Status = "SI", MailData = "" });
                _context.Configuraciones.Add(new Configuracion { Name = "Activar Notificación de Mantenimiento en Campo (Tareas)", Status = "SI", MailData = "" });
                _context.Configuraciones.Add(new Configuracion { Name = "Activar Notificación de Mantenimiento en Taller (Tareas)", Status = "SI", MailData = "" });
                _context.Configuraciones.Add(new Configuracion { Name = "Activar Notificación de Certificaciones de Equipo", Status = "SI", MailData = "" });
                _context.Configuraciones.Add(new Configuracion { Name = "Activar Notificación de Certificaciones de Personal", Status = "SI", MailData = "" });
                _context.Configuraciones.Add(new Configuracion { Name = "Activar Notificación de Documentos de Personal", Status = "SI", MailData = "" });
                await _context.SaveChangesAsync();

            }
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
                _context.Categories.Add(new Category { Name = "Apple" });
                _context.Categories.Add(new Category { Name = "Autos" });
                _context.Categories.Add(new Category { Name = "Belleza" });
                _context.Categories.Add(new Category { Name = "Calzado" });
                _context.Categories.Add(new Category { Name = "Comida" });
                _context.Categories.Add(new Category { Name = "Cosmeticos" });
                _context.Categories.Add(new Category { Name = "Deportes" });
                _context.Categories.Add(new Category { Name = "Erótica" });
                _context.Categories.Add(new Category { Name = "Ferreteria" });
                _context.Categories.Add(new Category { Name = "Gamer" });
                _context.Categories.Add(new Category { Name = "Hogar" });
                _context.Categories.Add(new Category { Name = "Jardín" });
                _context.Categories.Add(new Category { Name = "Jugetes" });
                _context.Categories.Add(new Category { Name = "Lenceria" });
                _context.Categories.Add(new Category { Name = "Mascotas" });
                _context.Categories.Add(new Category { Name = "Nutrición" });
                _context.Categories.Add(new Category { Name = "Ropa" });
                _context.Categories.Add(new Category { Name = "Tecnología" });
                await _context.SaveChangesAsync();
            }
        }

        //private async Task CheckCountriesAsync()
        //{
        //    if (!_context.Countries.Any())
        //    {
        //        _context.Countries.Add(
        //            new Country {
        //                Name = "Colombia",
        //                States = [ new State() { 
        //                    Name = "Antioquia", 
        //                    Cities = [ 
        //                        new City() { Name = "Medellín" }, 
        //                        new City() { Name = "Itagüí" }, 
        //                        new City() { Name = "Envigado" }, 
        //                        new City() { Name = "Bello" }, 
        //                        new City() { Name = "Rionegro" }, ] }, 
        //                    new State() { Name = "Bogotá",
        //                    Cities = [ 
        //                        new City() { Name = "Usaquen" }, 
        //                        new City() { Name = "Champinero" }, 
        //                        new City() { Name = "Santa fe" }, 
        //                        new City() { Name = "Useme" }, 
        //                        new City() { Name = "Bosa" }, 
        //                    ] 
        //                    }, 
        //                ]
        //            }
                    
        //            );
        //        _context.Countries.Add(new Country { Name = "Perú" });
        //        await _context.SaveChangesAsync();

        //    }
        //}
    }
}
