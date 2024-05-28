using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices;
using AlmoxarifadoServices.Interfaces;
using AlmoxarifadoServices.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContextSQL>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDBSQL")));

//Carregando Classes de Repositories
builder.Services.AddScoped<GrupoService>();
builder.Services.AddScoped<RepositoryModelCR<Grupo>,GrupoRepository>();
builder.Services.AddScoped<NotaFiscalService>();
builder.Services.AddScoped<RepositoryModelCRUD<NotaFiscal>, NotaFiscalRepository>();


var currentDomain = AppDomain.CurrentDomain;
var assemblies = currentDomain.GetAssemblies();

/*foreach (var assembly in assemblies)
{
    var types = assembly.GetTypes();
    foreach (var tipo in types)
    {
        //var @interfaces = tipo.GetInterfaces();

        //if (@interfaces!=null)
        //{
        //    foreach(Type @interface in interfaces)
        //        if(@interface.IsGenericType)

        //}
        var baseType = tipo.BaseType;
        if (baseType != null && baseType.IsGenericType)
        {
            if (baseType.GetGenericTypeDefinition() == typeof(ServiceModelCR<>) || baseType.GetGenericTypeDefinition() == typeof(ServiceModelCRUD<>))
            {

                builder.Services.AddScoped(baseType, tipo);
                /*
                var genericArguments = baseType.GetGenericArguments();
                foreach (var argument in genericArguments)
                {
                    var serviceType = typeof(ServiceModelCR<>).MakeGenericType(tipo);
                    var serviceType = baseType.MakeGenericType(argument);
                    builder.Services.AddScoped(serviceType, tipo);
                }
            }
            else
            if (baseType.GetGenericTypeDefinition() == typeof(RepositoryModelCR<>) || baseType.GetGenericTypeDefinition() == typeof(RepositoryModelCRUD<>))
            {
                builder.Services.AddScoped(baseType, tipo);
                /*var RepositoryType = typeof(ServiceModelCR<>).MakeGenericType(tipo);
                var genericArguments = baseType.GetGenericArguments();
                foreach (var argument in genericArguments)
                {
                    var RepositoryType = baseType.MakeGenericType(argument);
                    builder.Services.AddScoped(RepositoryType, tipo);
                }
                
            }
        }
    }
}
*/

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
