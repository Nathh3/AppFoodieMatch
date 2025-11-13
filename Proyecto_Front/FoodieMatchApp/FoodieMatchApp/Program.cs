using FoodieMatchApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;

namespace FoodieMatchApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            // Leer appsettings.json
            builder.Configuration.AddJsonFile("appsettings.json", optional: true);


            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5131/") });
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<RestauranteService>();
            builder.Services.AddScoped<ProductoService>();
            builder.Services.AddScoped<EleccionService>();
            builder.Services.AddScoped<CategoriaService>();





            await builder.Build().RunAsync();
        }
    }
}
