using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews(); // Soporte para MVC
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar servicios
builder.Services.AddSingleton<PracticaFinalAPI.Services.IProductoService, PracticaFinalAPI.Services.ProductoService>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
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
app.UseStaticFiles(); // Para archivos estáticos (CSS, JS, imágenes)
app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthorization();

// Configurar rutas para MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Productos}/{action=Index}/{id?}");

// Mantener las rutas de API
app.MapControllers();

// Health check endpoint
app.MapGet("/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }))
   .WithName("HealthCheck")
   .WithTags("Health");

// Endpoint raíz - redirige a la vista de productos
app.MapGet("/", () => Results.Redirect("/Productos"))
   .ExcludeFromDescription();

app.Run();
