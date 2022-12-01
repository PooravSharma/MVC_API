using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MVC_web.Models;
using MVC_web.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<Assessment2DatabaseSetting>(
                builder.Configuration.GetSection(nameof(Assessment2DatabaseSetting)));

builder.Services.AddSingleton<IAssessment2DatabaseSetting>(sp =>
sp.GetRequiredService<IOptions<Assessment2DatabaseSetting>>().Value);


builder.Services.AddScoped<IPlayersServices, PlayersServices>();
builder.Services.AddScoped<ICharactersServices, CharactersServices>();



builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
