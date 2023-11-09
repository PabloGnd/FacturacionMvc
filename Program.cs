using FacturacionMvc.Servicios;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClienteApi, ClienteApi>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClienteApi, ClienteApi>();
builder.Services.AddScoped<IProductoApi, ProductoApi>();
builder.Services.AddScoped<IRegistroApi, RegistroApi>();
builder.Services.AddScoped<IFacturaApi, FacturaApi>();
builder.Services.AddScoped<IUsuarioApi, UsuarioApi>();
builder.Services.AddScoped<IEstablecimientoApi, EstablecimientoApi>();
builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
   pattern: "{controller=Registro}/{action=Login}");
app.Run();
