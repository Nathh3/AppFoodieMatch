using FoodieMatchAPI.Repository.Implements;
using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Repositorios y consultas
builder.Services.AddTransient<IUsuarioQuery, UsuarioQuery>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IEleccionQuery, EleccionQuery>();
builder.Services.AddTransient<IEleccionRepository, EleccionRepository>();
builder.Services.AddTransient<IRestauranteQuery, RestauranteQuery>();
builder.Services.AddTransient<IRestauranteRepository, RestauranteRepository>();
builder.Services.AddTransient<IProductoQuery, ProductoQuery>();
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<ICategoriaQuery, CategoriaQuery>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

// Conexión a base de datos
builder.Services.AddScoped<IDbConnection>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("sql");
    return new SqlConnection(connectionString);
});


// 🔹 Configurar CORS para permitir todos los orígenes
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔹 Usar la política CORS antes de la autorización y mapeo de controladores
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
