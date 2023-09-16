using FiapStore.Interface;
using FiapStore.Logging;
using FiapStore.Repository;
using FiapStore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ITokenService, TokenService>();
//builder.Services.AddSingleton<IUserRepository, UserRepository>(); <- Dapper
builder.Services.AddScoped<IUserRepository, EFUserRepository>(); // <-EFCore
builder.Services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "FiapStore", Version = "v1" });
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    });

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration()
{
    LogLevel = LogLevel.Information
}));

var configurarion = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

var key = Encoding.ASCII.GetBytes(configurarion.GetValue<string>("Secret"));

builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); //ATENÇÃO - Autenticação sempre antes de autorização
app.UseAuthorization();

app.MapControllers();

app.Run();
