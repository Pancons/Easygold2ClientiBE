using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using EasyGold.API.Infrastructure;
using EasyGold.API.Services;
using MediatR;
using Microsoft.OpenApi.Models;
using EasyGold.API.Middleware;
using EasyGold.API.Repositories;
using System.Reflection;
using System.IdentityModel.Tokens.Jwt;
using EasyGold.API.Infrastructure.Swagger;

// --- REGISTRAZIONE REPOSITORY E SERVIZI ---
using EasyGold.API.Services.Implementations.ACL;
using EasyGold.API.Services.Implementations.Allegati;
using EasyGold.API.Services.Implementations.ConfigProgramma;
using EasyGold.API.Services.Implementations.GEO;
using EasyGold.API.Services.Implementations.Contabilita;
using EasyGold.API.Services.Implementations.ConfigData;
using EasyGold.API.Services.Interfaces.Allegati;
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.API.Services.Interfaces.ConfigProgramma;
using EasyGold.API.Services.Interfaces.Contabilita;
using EasyGold.API.Services.Interfaces.GEO;
using EasyGold.API.Services.Interfaces.ConfigData;
using EasyGold.API.Repositories.Implementations.Allegati;
using EasyGold.API.Repositories.Implementations.ConfigProgramma;
using EasyGold.API.Repositories.Implementations.GEO;
using EasyGold.API.Repositories.Implementations.Anagrafiche;
using EasyGold.API.Repositories.Implementations.Contabilita;
using EasyGold.API.Repositories.Implementations.ACL;
using EasyGold.API.Repositories.Implementations.ConfigData;
using EasyGold.API.Repositories.Interfaces.Allegati;
using EasyGold.API.Repositories.Interfaces.ConfigProgramma;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.API.Repositories.Interfaces.GEO;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;
using EasyGold.API.Repositories.Interfaces.Contabilita;
using EasyGold.API.Repositories.Interfaces.ConfigData;

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

builder.Services.AddHttpClient("WebhookClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5218/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    // eventuali autenticazioni qui
});


// 🔹 AutoMapper e MediatR
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUtenteRepository, UtenteRepository>();
builder.Services.AddScoped<IModuloRepository, ModuloRepository>();
builder.Services.AddScoped<IRuoloRepository, RuoloRepository>();
builder.Services.AddScoped<IAllegatoRepository, AllegatoRepository>();
builder.Services.AddScoped<INegozioRepository, NegozioRepository>();
builder.Services.AddScoped<INazioneRepository, NazioneRepository>();
builder.Services.AddScoped<IValutaRepository, ValutaRepository>();


builder.Services.AddScoped<IAllegatoService, AllegatoService>();
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<IAutenticazioneService, AutenticazioneService>();
builder.Services.AddScoped<IModuloService, ModuloService>();
builder.Services.AddScoped<IRuoloService, RuoloService>();
builder.Services.AddScoped<INazioneService, NazioneService>();
builder.Services.AddScoped<IValutaService, ValutaService>();

// --- REGISTRAZIONE REPOSITORY E SERVIZI AGGIUNTIVI ---
builder.Services.AddScoped<IRegistroIVARepository, RegistroIVARepository>();
builder.Services.AddScoped<IRegistroIVAService, RegistroIVAService>();

builder.Services.AddScoped<INumeriRegIVARepository, NumeriRegIVARepository>();
builder.Services.AddScoped<INumeriRegIVAService, NumeriRegIVAService>();

builder.Services.AddScoped<IConfigRepository, ConfigRepository>();
builder.Services.AddScoped<IConfigService, ConfigService>();

builder.Services.AddScoped<IConfigLangRepository, ConfigLangRepository>();
builder.Services.AddScoped<IConfigLangService, ConfigLangService>();

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
    c.OperationFilter<RestrictToJsonContentTypeFilter>();


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