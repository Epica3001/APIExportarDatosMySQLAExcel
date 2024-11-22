using DotNetEnv;
using ExportarDatosAExcelAPI.Helpers;
using ExportarDatosAExcelAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables de entorno desde el archivo .env
Env.Load();

// Configurar servicios de sus clases
builder.Services.AddControllers();
builder.Services.AddSingleton<DatabaseConnection>();
builder.Services.AddSingleton<DatabaseService>();
builder.Services.AddSingleton<ExcelExportService>();

var app = builder.Build();

// Configurar middleware
app.MapControllers();
app.Run();