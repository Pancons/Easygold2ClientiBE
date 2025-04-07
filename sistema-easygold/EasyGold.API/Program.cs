using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using EasyGold.API.Infrastructure;
using EasyGold.API.Services;
using EasyGold.API.Services.Interfaces;
using MediatR;
using Microsoft.OpenApi.Models;
using EasyGold.API.Middleware;
using EasyGold.API.Repositories.Interfaces;
using EasyGold.API.Repositories;
using EasyGold.API.Repositories.Implementations;
using System.Reflection;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configura Serilog per il logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

// 🔹 Configura Entity Framework Core con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔹 Configura l'autenticazione JWT
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]); // Carica da appsettings.json
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });



// 🔹 AutoMapper e MediatR
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IUtenteRepository, UtenteRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IModuloRepository, ModuloRepository>();
builder.Services.AddScoped<IRuoloRepository, RuoloRepository>();
builder.Services.AddScoped<IAllegatoRepository, AllegatoRepository>();
builder.Services.AddScoped<INegozioRepository, NegozioRepository>();
builder.Services.AddScoped<IModuloClienteRepository, ModuloClienteRepository>();
builder.Services.AddScoped<INazioneRepository, NazioneRepository>();
builder.Services.AddScoped<IValutaRepository, ValutaRepository>();


builder.Services.AddScoped<EasyGold.API.Services.Interfaces.IAllegatoService, EasyGold.API.Services.Implementations.AllegatoService>();
builder.Services.AddScoped<EasyGold.API.Services.Interfaces.IClienteService, EasyGold.API.Services.Implementations.ClienteService>();
builder.Services.AddScoped<EasyGold.API.Services.Interfaces.IUtenteService, EasyGold.API.Services.Implementations.UtenteService>();
builder.Services.AddScoped<EasyGold.API.Services.Interfaces.IAutenticazioneService, EasyGold.API.Services.Implementations.AutenticazioneService>();
builder.Services.AddScoped<EasyGold.API.Services.Interfaces.IModuloService, EasyGold.API.Services.Implementations.ModuloService>();
builder.Services.AddScoped<EasyGold.API.Services.Interfaces.IRuoloService, EasyGold.API.Services.Implementations.RuoloService>();
builder.Services.AddScoped<EasyGold.API.Services.Interfaces.INazioneService, EasyGold.API.Services.Implementations.NazioneService>();
builder.Services.AddScoped<EasyGold.API.Services.Interfaces.IValutaService, EasyGold.API.Services.Implementations.ValutaService>();

// 🔹 Abilita i controller e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EasyGold API",
        Version = "v1",
        Description = "API per la gestione utenti e clienti in EasyGold",
        Contact = new OpenApiContact
        {
            Name = "Supporto EasyGold",
            Email = "support@easygold.com",
            Url = new Uri("https://easygold.com")
        },
        License = new OpenApiLicense
        {
            Name = "Licenza MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
        
    });
    c.EnableAnnotations(); // Abilita le annotazioni Swagger
   
        
    // 🔹 Legge i commenti XML per documentare Swagger
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    // 🔹 Aggiunta autenticazione JWT a Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Inserisci il token JWT nel formato: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// 🔹 Aggiungi CORS (se serve per frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();



// 🔹 Middleware globali
app.UseMiddleware<ErrorHandlingMiddleware>(); // Gestione errori personalizzata
 
          

app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Abilita CORS
app.UseAuthentication();
app.UseAuthorization();

// 🔹 Abilita Swagger solo in sviluppo
if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("EnableSwagger"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyGold API v1"));
}

// 🔹 Mappa i controller
app.MapControllers();

app.Run();

public partial class Program { }