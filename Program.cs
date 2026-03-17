using carritonet.Data;
using carritonet.Services;                          // ✅ AGREGAR
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var builder = WebApplication.CreateBuilder(args);


// ✅ CORS — AGREGAR ESTO
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


// ✅ Conexión a Neon PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration
           .GetConnectionString("DefaultConnection")));

// ✅ Registrar AuthService                         // ✅ AGREGAR
builder.Services.AddScoped<IAuthService, AuthService>();

// ✅ JWT                                           // ✅ AGREGAR
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateLifetime         = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer              = builder.Configuration["Jwt:Issuer"],
            ValidAudience            = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey         = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

// ✅ Controladores + Vistas (React)
builder.Services.AddControllersWithViews();

// ✅ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Después — siempre activo
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarritoNet API v1");
    c.RoutePrefix = string.Empty; // ← abre Swagger en la ruta raíz "/"
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll");  
app.UseAuthentication();                            // ✅ AGREGAR — antes de Authorization
app.UseAuthorization();                             // ✅ AGREGAR

// ✅ Rutas API
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
