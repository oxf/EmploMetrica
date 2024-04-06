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
using EmploMetrica.Application.UseCases.Users;
using MassTransit;
using EmploMetrica.Infrastructure.Services;
using EmploMetrica.Infrastructure.Interfaces.Authentication;
using EmploMetrica.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using EmploMetrica.Application.UseCases.Time;
using MassTransit.Configuration;

var builder = WebApplication.CreateBuilder(args);

// API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ExceptionHandlingMiddleware>();
builder.Services.AddControllers();


// Persistence
builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                   builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Messaging
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMq"));
builder.Services.AddSingleton<RabbitMqConfiguration>(
    sg => sg.GetRequiredService<IOptions<RabbitMqConfiguration>>().Value    
);
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.AddConsumer<ConsumeTimeEventUseCase>();
    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        RabbitMqConfiguration configuration = context.GetRequiredService<RabbitMqConfiguration>();
        configurator.Host(new Uri(configuration.Host), h =>
        {
            h.Username(configuration.Username);
            h.Password(configuration.Password);
        });
        configurator.ConfigureEndpoints(context);
    });
});
builder.Services.AddTransient<IMessageProducer, RabbitMqMessageProducer>();

// Application Services
builder.Services.AddScoped<ICrudService<GetCompanyDTO, CreateCompanyDTO, UpdateCompanyDTO>, CompanyService>();
builder.Services.AddScoped<ICrudChildService<GetDepartmentDTO, CreateDepartmentDTO, UpdateDepartmentDTO>, DepartmentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ProduceTimeEventUseCase>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Infrastructure Services
builder.Services.AddLogging(logger =>
    logger.AddConsole()
);
builder.Services.AddScoped<IAuthTokenService, JwtAuthService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

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
