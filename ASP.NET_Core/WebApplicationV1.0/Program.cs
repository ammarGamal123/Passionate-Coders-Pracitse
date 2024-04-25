
using Microsoft.EntityFrameworkCore;
using WebApplicationV1._0.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Make .NET know what is weatherforecastservice ==> Dependency Registration 
// 
// builder.Services.AddScoped<IWeatherForecaseService , WeatherForecaseService>();

builder.Services.AddDbContext<ApplicationDbContext>(
   builder => builder.UseSqlServer("server=.;database=Products;" +
   "integrated security = true; trust server certificate=true")
    );

var app = builder.Build();

// Configure the HTTP request pipelinr.

if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
