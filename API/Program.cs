using Application.Services;
using Domain.Repositories;
using Domain.Services;
using Infra;
using Infra.Repositories;
using Infra.Services;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMedicoServices, MedicoServices>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IHorarioDisponivelRepository, HorarioDisponivelRepository>();
builder.Services.AddScoped<IHorarioDisponivelService, HorarioDisponivelService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();

using var scope = app.Services?.GetService<IServiceScopeFactory>()?.CreateScope();
var context = scope?.ServiceProvider.GetRequiredService<Context>();
context?.Database.Migrate();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseHttpMetrics();
app.UseMetricServer();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapMetrics();
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

public partial class Program { }