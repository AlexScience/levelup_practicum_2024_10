using LevelUp.Practicum.API.DataAccess;
using LevelUp.Practicum.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connStr = builder.Configuration.GetConnectionString("TicketsDb");
builder.Services.AddDbContext<TicketsDbContext>(opt => opt.UseNpgsql(connStr));
builder.Services.AddScoped<IPassengersService, PassengersService>();
builder.Services.AddScoped<ITicketsService, TicketsService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();