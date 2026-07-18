using Dweb_TrabalhoFinal.Data;
using Dweb_TrabalhoFinal.Data.Seed;
using Dweb_TrabalhoFinal.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Configura��o �nica da Base de Dados conectada ao Azure
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=tcp:cineticket-server.database.windows.net,1433;Initial Catalog=cineticket-database;Persist Security Info=False;User ID=cineticket-server-admin;Password=mxmv$OeK0bkJap1$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() // <-- ATIVA O SUPORTE A PERFIS (ADMIN/CLIENTE)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Venda de Bilhetes Online",
        Version = "v1",
        Description = "API para gest�o de filmes"
    });
});

// JWT Settings
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(options => { })
   .AddCookie("Cookies", options => {
       options.LoginPath = "/Identity/Account/Login";
       options.AccessDeniedPath = "/Identity/Account/AccessDenied";
   })
   .AddJwtBearer("Bearer", options => {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = jwtSettings["Issuer"],
           ValidAudience = jwtSettings["Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(key)
       };
   });

builder.Services.AddScoped<Dweb_TrabalhoFinal.Tools.TokenService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    // Usar os m�todos de seed originais do teu projeto
    app.UseItToSeedSqlServer();

    // iniciar o 'middleware' do Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

// =================================================================================================
// ALTERA��O 2: Cria��o autom�tica da Role "Admin" e do utilizador Admin se n�o existirem
// =================================================================================================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        // 1. Criar o perfil de Admin se ele n�o existir
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // 2. Criar o utilizador Administrador padr�o
        var adminEmail = "admin@cinema.pt";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var newAdmin = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            // Criar com uma senha forte padr�o
            var result = await userManager.CreateAsync(newAdmin, "Admin123!");

            if (result.Succeeded)
            {
                // Vincula esta conta especificamente � Role Admin
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao rodar o Seed de Roles: {ex.Message}");
    }
}

app.Run();