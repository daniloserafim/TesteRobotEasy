using ApiCotacao.Controllers;
using ApiCotacao.Model;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Cotacoes"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

//app.MapGet("/Cotacao/{moedaBase}/{moedaAlvo}", (string moedaBase, string moedaAlvo) => CotacaoController.GetCotacao(moedaBase, moedaAlvo));
app.MapGet("/nelson/{moedaBase}/{moedaAlvo}", async (string moedaBase, string moedaAlvo, AppDbContext dbContext) => await dbContext.Cotacoes.FirstOrDefaultAsync(item => item.moedaBase == moedaBase && item.moedaAlvo == moedaAlvo));
app.MapGet("/Cotacoes", async (AppDbContext dbContext) => await dbContext.Cotacoes.ToListAsync());
app.MapPost("/Cotacoes", async (Cotacao cotacao, AppDbContext dbContext) =>
{
    dbContext.Cotacoes.Add(cotacao);
    await dbContext.SaveChangesAsync();

    return cotacao;
});

app.Run();