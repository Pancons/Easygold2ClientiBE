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
using EasyGold.API.Services.Interfaces.ACL;
using EasyGold.API.Repositories.Implementations.ACL;
using EasyGold.API.Repositories.Interfaces.ACL;
using EasyGold.API.Services.Implementations.Anagrafiche;
using EasyGold.API.Services.Interfaces.Anagrafiche;
using EasyGold.API.Repositories.Implementations.Anagrafiche;
using EasyGold.API.Repositories.Interfaces.Anagrafiche;


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

builder.Services.AddScoped<IAutenticazioneService, AutenticazioneService>();
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<IFiscalePostazioniService, FiscalePostazioniService>();
builder.Services.AddScoped<IFunzioniService, FunzioniService>();
builder.Services.AddScoped<IGruppiService, GruppiService>();
builder.Services.AddScoped<ILettorePostazioniService, LettorePostazioniService>();
builder.Services.AddScoped<IModuliStampeService, ModuliStampeService>();
builder.Services.AddScoped<IPermessiGruppoService, PermessiGruppoService>();
builder.Services.AddScoped<IPwUtentiService, PwUtentiService>();
builder.Services.AddScoped<IRegFiscaleService, RegFiscaleService>();
builder.Services.AddScoped<ISessioniEasyGoldService, SessioniEasyGoldService>();
builder.Services.AddScoped<IStampePostazioniService, StampePostazioniService>();
builder.Services.AddScoped<ITestataPostazioniService, TestataPostazioniService>();
builder.Services.AddScoped<ITipoPermessoService, TipoPermessoService>();
builder.Services.AddScoped<ITipoPwService, TipoPwService>();
builder.Services.AddScoped<IUtenteNegoziService, UtenteNegoziService>();
builder.Services.AddScoped<IUtentePostazioneService, UtentePostazioneService>();


builder.Services.AddScoped<IUtenteRepository, UtenteRepository>();
builder.Services.AddScoped<IFiscalePostazioniRepository, FiscalePostazioniRepository>();
builder.Services.AddScoped<IFunzioniRepository, FunzioniRepository>();
builder.Services.AddScoped<IGruppiRepository, GruppiRepository>();
builder.Services.AddScoped<ILettorePostazioniRepository, LettorePostazioniRepository>();
builder.Services.AddScoped<IModuliStampeRepository, ModuliStampeRepository>();
builder.Services.AddScoped<IPermessiGruppoRepository, PermessiGruppoRepository>();
builder.Services.AddScoped<IPwUtentiRepository, PwUtentiRepository>();
builder.Services.AddScoped<IRegFiscaleRepository, RegFiscaleRepository>();
builder.Services.AddScoped<ISessioniEasyGoldRepository, SessioniEasyGoldRepository>();
builder.Services.AddScoped<IStampePostazioniRepository, StampePostazioniRepository>();
builder.Services.AddScoped<ITestataPostazioniRepository, TestataPostazioniRepository>();
builder.Services.AddScoped<ITipoPermessoRepository, TipoPermessoRepository>();
builder.Services.AddScoped<ITipoPwRepository, TipoPwRepository>();
builder.Services.AddScoped<IUtenteNegoziRepository, UtenteNegoziRepository>();
builder.Services.AddScoped<IUtentePostazioneRepository, UtentePostazioneRepository>();



//
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