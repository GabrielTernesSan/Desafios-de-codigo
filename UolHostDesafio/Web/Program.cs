using Application.Handlers;
using Domain.Queries;
using Domain.Repositories;
using Infra;
using Infra.Queries;
using Infra.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
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
builder.Services.AddSingleton<IHeroiApi, VingadoresRest>();

builder.Services.AddDbContext<Context>();
builder.Services.AddDbContext<ContextMemory>(optional => optional.UseInMemoryDatabase("Database"));
builder.Services.AddTransient<IJogadorRepository, JogadorRepository>();
builder.Services.AddTransient<IVingadorRepository, VingadorRepository>();
builder.Services.AddTransient<IJogadorQuery, JogadorQuery>();
builder.Services.AddTransient<IVingadoresQuery, VingadoresQuery>();

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
