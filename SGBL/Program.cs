using CapaDatos.DataContext;
using CapaDatos.repositorio;
using CapaNegocio.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Login/Index";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    option.AccessDeniedPath = "/Home/Privacy";
});

builder.Services.AddDbContext<LibreriaTiendaContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});


//usuario
builder.Services.AddScoped<InterfaceUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IServiceUsuario, ServiceUsuario>();
//libros
builder.Services.AddScoped<InterfaceLibro, RepositorioLibro>();
builder.Services.AddScoped<IServiceLibro, ServiceLibro>();
//Autor
builder.Services.AddScoped<InterfaceAutor, RepositorioAutor>();
builder.Services.AddScoped<IServiceAutor, ServiceAutor>();
//genero
builder.Services.AddScoped<InterfaceGeneros, RepositorioGeneros>();
builder.Services.AddScoped<IServiceGenero, ServiceGenero>();
//prestamos
builder.Services.AddScoped<InterfacePrestamos, RepositorioPrestamos>();
builder.Services.AddScoped<IServicePrestamos,  ServicePrestamos>();
//Reserva
builder.Services.AddScoped<InterfaceReservas, RepositorioReservas>();
builder.Services.AddScoped<IServiceReserva, ServiceReserva>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
