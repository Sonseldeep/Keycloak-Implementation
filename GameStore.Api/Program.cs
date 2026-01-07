using GameStore.Api.Database;
using GameStore.Api.ErrorHandling;
using GameStore.Api.Extension;
using GameStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails()
    .AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddXmlSerializerFormatters();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Database"),
        useSqlServer => useSqlServer.MigrationsHistoryTable(HistoryRepository.DefaultTableName,Schema.Application))
    );

builder.Services.AddScoped<IGameRepository,GameRepository>();
builder.AddTemplateAppCors();
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = "http://localhost:8080/realms/gamestore-api";
        options.Audience = "gamestore-api";
        options.RequireHttpsMetadata = false;
    });
builder.Services.AddAuthorizationBuilder();

var app = builder.Build();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseSwagger();
    app.UseSwaggerUI();

    await app.ApplyMigrationsAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();