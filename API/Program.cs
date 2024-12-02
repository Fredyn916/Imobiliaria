using Core.DataBase.CloudinaryConfig;
using Core.DataBase.MongoDb.Extensoes;
using Core.DataBase.SQLite;
using Core.Repositorios;
using Core.Services;
using Entidades.DTOs;
using Entidades.Interfaces.Imoveis;
using Entidades.Interfaces.Usuarios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});



ExtensoesProgramMongo.AddConfiguracaoMongo(builder.Services, builder.Configuration);

Startup.ConfigureServices(builder.Configuration, builder.Services);

InicializadorDb.Inicializar();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IImovelRepository, ImovelRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IImovelService, ImovelService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Permite requisições de qualquer origem (CORS)
app.UseCors("PermitirTudo");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
