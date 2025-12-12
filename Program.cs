using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebFamilyHome.Data;
using WebFamilyHome.Models;

var builder = WebApplication.CreateBuilder(args);

// Conexão com PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração do Identity
builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>();

// 🔹 Ajuste do cookie de autenticação
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";        // rota de login
    options.AccessDeniedPath = "/Account/Login"; // rota de acesso negado
});

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

app.UseAuthentication();
app.UseAuthorization();

// 🔹 Rota inicial: Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
