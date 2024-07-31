using ProofIdentity.WebApi.Injections;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration.AddJsonFile("appsettings.Local.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterEF(configuration);
builder.Services.RegisterIdentity();
builder.Services.RegisterServices(configuration);
builder.Services.RegisterUseCases();

builder.Services.RegisterSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// NOTE: Authentication tem que vim primeiro que authorization,
// ficar imposivel fazer a authenticação no sistema, vai saber.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// TODO: fazer um sistema de roles
// TODO: fazer uma sistema que uma role tem uma clase propria
// porem com metodos diferente
// TODO: ver qual é o melhor lugar para deixar os metodos de login
// Ex. na ILoginService ou na Repository
