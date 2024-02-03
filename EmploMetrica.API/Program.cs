using EmploMetrica.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using EmploMetrica.Domain;
using System.Text.Json.Serialization;
using EmploMetrica.API.Middleware;
using EmploMetrica.Application.UseCases.Companies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                   builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ExceptionHandlingMiddleware>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
