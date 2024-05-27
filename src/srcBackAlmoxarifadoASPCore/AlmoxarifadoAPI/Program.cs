using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices.Interfaces;
using AlmoxarifadoServices.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContextSQL>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDBSQL")));

//Carregando Classes de Repositories

var currentDomain = AppDomain.CurrentDomain;
var assemblies = currentDomain.GetAssemblies();

foreach (var assembly in assemblies)
{
    var types = assembly.GetTypes();
    foreach (var type in types)
    {
        var isService = type.GetInterfaces()
            .Where(i => i.IsGenericType)
            .Any(i => i.GetGenericTypeDefinition() == typeof(ServiceModelCR<>) || i.GetGenericTypeDefinition() == typeof(ServiceModelCRUD<>));

        if (isService)
        {
            builder.Services.AddScoped<Type>();
        }

        var isRepository = type.GetInterfaces()
            .Where(i => i.IsGenericType)
            .Any(i => i.GetGenericTypeDefinition() == typeof(RepositoryModelCR<>) || i.GetGenericTypeDefinition() == typeof(RepositoryModelCRUD<>));

        if (isRepository)
        {

            builder.Services.AddScoped<Type>();

        }
    }
}


//builder.Services.AddScoped<GrupoService>();
//builder.Services.AddScoped<IRepositoryCR<Grupo>,GrupoRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
