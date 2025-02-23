using Microsoft.EntityFrameworkCore;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ApiGlobalExceptionFilter))).AddJsonOptions(jsonOptions => { });
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(StartServiceHandler).Assembly));

builder.Services.AddDbContext<MicrowaveContext>(options => options.UseInMemoryDatabase("memory"));

builder.Services.AddSingleton<NotificationService>();
builder.Services.AddSingleton<ICountdownBackgroundService, CountdownBackgroundService>();

builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IUnitOfWork, MicrowaveContext>();
builder.Services.AddScoped<IHeatingProgramRepository, HeatingProgramRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

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
