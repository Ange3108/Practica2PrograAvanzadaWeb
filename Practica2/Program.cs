using Microsoft.EntityFrameworkCore;
using Practica2.BLL;
using Practica2.BLL.Service.Categoria;
using Practica2.BLL.Service.Producto;
using Practica2.DAL.Data;
using Practica2.DAL.Repository;
using Practica2.DAL.Repository.Categoria;
using Practica2.DAL.Repository.Producto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Register EF Core DbContext (Microsoft SQL Server). Update the connection string in appsettings.json

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Practica2Conn")));



//Inyección de dependencias para repositorios, servicios, etc.

//// Repositorios

// Repositorio Generico
builder.Services.AddScoped(
    typeof(IRepositorioGenerico<>),
    typeof(RepositorioGenerico<>));


// Repositorios Especificos (no requeridos, sólo para cambios de comportamiento a futuro)
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();


////Servicios
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();

//// Servicios Terceros
builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClases)); //Mapeo de Clases - Automapper


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

