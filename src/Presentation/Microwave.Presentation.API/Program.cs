using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microwave.Application.Services;
using Microwave.Application.UseCases.MicrowaveService.StartService;
using Microwave.Domain.Repositories;
using Microwave.Domain.SeedWork;
using Microwave.Infrastructure.Data.Contexts;
using Microwave.Infrastructure.Data.Repositories;
using Microwave.Infrastructure.Services.Countdown;
using Microwave.Infrastructure.Services.Encryption;
using Microwave.Infrastructure.Services.Hubs;
using Microwave.Infrastructure.Services.Token;
using Microwave.Presentation.API.Filters;
using Microwave.Presentation.API.Initializations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ApiGlobalExceptionFilter))).AddJsonOptions(jsonOptions => { });
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.\r\n\r\n Enter 'Bearer'[space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });

    //c.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, Array.Empty<string>() } });
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
            Array.Empty<string>()
        }
    });

    c.OperationFilter<SwaggerRemoveAuthFilter>();
});


builder.Services.AddSignalR();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(StartServiceHandler).Assembly));

builder.Services.AddDbContext<MicrowaveContext>(options => options.UseInMemoryDatabase("memory"));

builder.Services.AddSingleton<NotificationService>();
builder.Services.AddSingleton<ICountdownBackgroundService, CountdownBackgroundService>();

builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IHeatingProgramRepository, HeatingProgramRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DbInitializer.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microwave"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<HeatingNotificationHab>("/heatingHub");

app.Run();
