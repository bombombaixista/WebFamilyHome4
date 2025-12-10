using Microsoft.EntityFrameworkCore;
using WebFamilyHome.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona suporte a Controllers + Views (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware padrão
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// 👉 Rota padrão: raiz "/" chama ValidateController.Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Validate}/{action=Index}/{id?}");

app.Run();
