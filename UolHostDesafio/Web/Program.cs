using Application.Handlers.Jogadores;
using Application.Handlers.Vingador;
using Domain.Queries;
using Domain.Repositories;
using Infra;
using Infra.Queries;
using Infra.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Web.HostedService;
using Web.Interfaces;
using Web.Rest;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(AddJogadorHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(AlterarJogadorHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(ExcluirJogadorHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(AddVingadorHandler).GetTypeInfo().Assembly);

builder.Services.AddSingleton<IVingadorService, VingadorService>();
builder.Services.AddSingleton<IVingadorApi, VingadoresRest>();
builder.Services.AddSingleton<ILigaService, LigaService>();
builder.Services.AddSingleton<ILigaApi, LigaRest>();

builder.Services.AddDbContext<Context>();
builder.Services.AddDbContext<ContextMemory>(optional => optional.UseInMemoryDatabase("Database"));

builder.Services.AddHostedService<HeroisHostedService>();

builder.Services.AddTransient<IJogadorRepository, JogadorRepository>();
builder.Services.AddTransient<IVingadorRepository, VingadorRepository>();
builder.Services.AddTransient<ILigaRespository, LigaRepository>();
builder.Services.AddTransient<IJogadorQuery, JogadorQuery>();
builder.Services.AddTransient<IVingadoresQuery, VingadoresQuery>();
builder.Services.AddTransient<ILigaQuery, LigaQuery>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
