using CornwayWeb.Repositories;
using CornwayWeb.Services;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add scoped repositories
builder.Services.AddScoped<ICosechaRepository, CosechaRepository>();
builder.Services.AddScoped<ICultivoRepository, CultivoRepository>();
builder.Services.AddScoped<IGestionCultivoRepository, GestionCultivoRepository>();
builder.Services.AddScoped<IInsumoCultivoRepository,  InsumoCultivoRepository>();
builder.Services.AddScoped<IInsumoGestionCultivoRepository, InsumoGestionCultivoRepository>();
builder.Services.AddScoped<IPartidaRepository, PartidaRepository>();
builder.Services.AddScoped<ITipoCultivoRepository, TipoCultivoRepository>();
builder.Services.AddScoped<ITipoGestionCultivoRepository, TipoGestionCultivoRepository>();
builder.Services.AddScoped<ITipoInsumoGestionCultivoRepository, TipoInsumoGestionCultivoRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//add scoped services
builder.Services.AddScoped<ICosechaService, CosechaService>();
builder.Services.AddScoped<ICultivoService, CultivoService>();
builder.Services.AddScoped<IGestionCultivoService, GestionCultivoService>();
builder.Services.AddScoped<IInsumoCultivoService, InsumoCultivoService>();
builder.Services.AddScoped<IInsumoGestionCultivoService, InsumoGestionCultivoService>();
builder.Services.AddScoped<IPartidaService, PartidaService>();
builder.Services.AddScoped<ITipoCultivoService, TipoCultivoService>();
builder.Services.AddScoped<ITipoGestionCultivoService, TipoGestionCultivoService>();
builder.Services.AddScoped<ITipoInsumoGestionCultivoService, TipoInsumoGestionCultivoService>();
builder.Services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();