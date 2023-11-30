using Microsoft.EntityFrameworkCore;
using TP02.Context;
using WebAPI.Repositories;

//Marcelo Modesto de Lima Junior CB3015823
//Bruna Helena Silva Santos      CB3016111

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connection = builder.Configuration.GetSection("ConexaoSqlite:SqliteConnectionString").Value;
builder.Services.AddDbContext<TpContext>(options =>
    options.UseSqlite(connection)
);

//Services
builder.Services.AddTransient<AtividadesRepository>();

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
