using Microsoft.EntityFrameworkCore;
using Planimaq.backend.Data;
using Planimaq.backend.Repositories.Implementations;
using Planimaq.backend.Repositories.Interfaces;
using Planimaq.backend.UnitsOfWork.Implementations;
using Planimaq.backend.UnitsOfWork.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    opt => {
        opt.UseSqlServer(
        builder.Configuration.GetConnectionString("LocalConnection")
        );
    });

builder.Services.AddTransient<SeedDb>();

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>),typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


builder.Services.AddScoped<ICategoriesUnitOfWork,CategoriesUnitOfWork>();
builder.Services.AddScoped<ICitiesUnitOfWork, CitiesUnitOfWork>();
builder.Services.AddScoped<ICountriesUnitOfWork, CountriesUnitOfWork>();
builder.Services.AddScoped<IStatesUnitOfWork, StatesUnitOfWork>();

builder.Services.AddScoped<ICategoriesRepository,CategoriesRepository>();
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<IStatesRepository, StatesRepository>();

var app = builder.Build();

Seeddata(app);

void Seeddata(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDb>(); 
         service!.SeedAsync().Wait();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();