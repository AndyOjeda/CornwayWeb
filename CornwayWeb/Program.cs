using CornwayWeb.Repositories;
using CornwayWeb.Services;
using CornwayWeb.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connString));

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add scoped repositories
builder.Services.AddScoped<ICosechaRepository, CosechaRepository>();
builder.Services.AddScoped<ICultivosRepository, CultivosRepository>();
builder.Services.AddScoped<IGestionesCultivoRepository, GestionesCultivoRepository>();
builder.Services.AddScoped<IInsumoCultivoRepository,  InsumoCultivoRepository>();
builder.Services.AddScoped<IInsumosGestionCultivoRepository, InsumosGestionCultivoRepository>();
builder.Services.AddScoped<IPartidaRepository, PartidaRepository>();
builder.Services.AddScoped<ITiposCultivoRepository, TiposCultivoRepository>();
builder.Services.AddScoped<ITiposGestionCultivoRepository, TiposGestionCultivoRepository>();
builder.Services.AddScoped<ITiposInsumoGestionCultivoRepository, TiposInsumoGestionCultivoRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();

//add scoped services
builder.Services.AddScoped<ICosechaService, CosechaService>();
builder.Services.AddScoped<ICultivosService, CultivosService>();
builder.Services.AddScoped<IGestionesCultivoService, GestionesCultivoService>();
builder.Services.AddScoped<IInsumoCultivoService, InsumoCultivoService>();
builder.Services.AddScoped<IInsumosGestionCultivoService, InsumosGestionCultivoService>();
builder.Services.AddScoped<IPartidaService, PartidaService>();
builder.Services.AddScoped<ITiposCultivoService, TiposCultivoService>();
builder.Services.AddScoped<ITiposGestionCultivoService, TiposGestionCultivoService>();
builder.Services.AddScoped<ITiposInsumoGestionCultivoService, TiposInsumoGestionCultivoService>();
builder.Services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAllOrigins");
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();