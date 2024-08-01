using System.Text;
using System.Xml.Serialization;
using CobroSmart.Application.IServices;
using CobroSmart.Application.Services;
using CobroSmart.Application.Utils;
using CobroSmart.Domain.Builder;
using CobroSmart.Domain.Mappers;
using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Context;
using CobroSmart.Infrastructure.Repository;
using CobroSmart.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<CobroSmartContext>(options => options.UseSqlServer(connectionString));

//Configuracion para consultas que usan la misma instancia del contexto (CobroSmartContext) y se ejecutan en paralelo
builder.Services.AddDbContextFactory<CobroSmartContext>((sp, options) =>
{
    options.UseSqlServer(connectionString);
}, ServiceLifetime.Scoped);

//Mappers
builder.Services.AddScoped<UserMapper>();
builder.Services.AddScoped<RoleMapper>();
builder.Services.AddScoped<CompanyMapper>();

//Repositories dependencies
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Role>, RoleRepository>();
builder.Services.AddScoped<IRepository<Company>, CompanyRepository>();

//Services and response
builder.Services.AddScoped<ResponseBuild>();
builder.Services.AddScoped<Util>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//Jwt configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]!))
    };
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
}).AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
