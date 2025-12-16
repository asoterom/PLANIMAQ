using Microsoft.EntityFrameworkCore;
using Planimaq.backend.Data;
using Planimaq.backend.Repositories.Implementations;
using Planimaq.backend.Repositories.Interfaces;
using Planimaq.backend.UnitsOfWork.Implementations;
using Planimaq.backend.UnitsOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    opt => {
        opt.UseSqlServer(
        builder.Configuration.GetConnectionString("LocalConnection")
        );
    });

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>),typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();