using CancellationTokenProof.Server;
using CancellationTokenProof.Server.Repositories;
using CancellationTokenProof.Server.UseCases;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
configuration.AddJsonFile("appsettings.Local.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DbSqlServer")!));


builder.Services.AddScoped<PlayerRepository>();

builder.Services.AddScoped<CountUntilCancelUseCase>();
builder.Services.AddScoped<CreatePlayerUseCase>();
builder.Services.AddScoped<DeletePlayerUseCase>();

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
