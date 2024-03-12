using EmploMetrica.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using EmploMetrica.Domain;
using System.Text.Json.Serialization;
using EmploMetrica.API.Middleware;
using EmploMetrica.Application.UseCases.Companies;
using EmploMetrica.Application.UseCases.Departments;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Domain.Departments;
using EmploMetrica.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EmploMetrica.Application.UseCases;
using EmploMetrica.Infrastructure;
using EmploMetrica.Application.UseCases.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                   builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ExceptionHandlingMiddleware>();
builder.Services.AddScoped<ICrudService<GetCompanyDTO, CreateCompanyDTO, UpdateCompanyDTO>, CompanyService>();
builder.Services.AddScoped<ICrudChildService<GetDepartmentDTO, CreateDepartmentDTO, UpdateDepartmentDTO>, DepartmentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IAuthTokenService, JwtAuthService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
