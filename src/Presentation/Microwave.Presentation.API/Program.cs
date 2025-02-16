using Microsoft.EntityFrameworkCore;
using Microwave.Application.Hubs;
using Microwave.Application.Services;
using Microwave.Application.UseCases.MicrowaveService.StartService;
using Microwave.Domain.Repositories;
using Microwave.Domain.SeedWork;
using Microwave.Infrastructure.Data.Contexts;
using Microwave.Infrastructure.Data.Repositories;
using Microwave.Infrastructure.Services.Countdown;
using Microwave.Presentation.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ApiGlobalExceptionFilter>())
    .AddJsonOptions(jsonOptions =>
    {
        //jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCasePolicy();
    });

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(StartServiceHandler).Assembly));

builder.Services.AddDbContext<MicrowaveContext>(options => options.UseInMemoryDatabase("memory"));

builder.Services.AddSingleton<ICountdownBackgroundService, CountdownBackgroundService>();

builder.Services.AddTransient<IUnitOfWork, MicrowaveContext>();
builder.Services.AddTransient<IHeatingProgramRepository, HeatingProgramRepository>();



builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<HeatingNotificationHub>("/heating_hub");

app.Run();
