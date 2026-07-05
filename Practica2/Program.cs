using Microsoft.EntityFrameworkCore;
using Practica2.BLL;
using Practica2.DAL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Register EF Core DbContext (Microsoft SQL Server). Update the connection string in appsettings.json

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Practica2Conn")));



//Inyección de dependencias para repositorios, servicios, etc.

//// Repositorios
//builder.Services.AddScoped<ICarroRepositorio, CarroRepositorio>();
//builder.Services.AddScoped<IDuennoRepositorio, DuennoRepositorio>();

////Servicios
//builder.Services.AddScoped<ICarroServicio, CarroServicio>();
//builder.Services.AddScoped<IDuennoServicio, DuennoServicio>();

//// Servicios Terceros
//builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClases)); // Directamente desde la documentación


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

