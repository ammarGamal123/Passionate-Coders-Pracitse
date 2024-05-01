
using Microsoft.EntityFrameworkCore;
using WebApplicationV1._0;
using WebApplicationV1._0.Data;
using WebApplicationV1._0.Filters;
using WebApplicationV1._0.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Register Your Configuration Json File into Configuration AddJsonFile
builder.Configuration.AddJsonFile("Config.Json");

// Add services to the container.

// Here We register a filter we made (Called Global Filter)
builder.Services.AddControllers(/*options =>
{
    // It Will be executed in every action 
    options.Filters.Add<LogActivityFilter>();
})*/);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Make .NET know what is weatherforecastservice ==> Dependency Registration 
// 
// builder.Services.AddScoped<IWeatherForecaseService , WeatherForecaseService>();

builder.Services.AddDbContext<ApplicationDbContext>(
   cfg => cfg.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]
   ));


// First way to register configuration (Not Prefered)
/*
var attachmentsOptions = builder.Configuration.GetSection("Attachments")
                        .Get<AttachmentsOptions>();

builder.Services.AddSingleton(attachmentsOptions);
*/


// Second way to register configuration (Not Prefered)

/*var attachments = new AttachmentsOptions();
builder.Configuration.GetSection("Attachment").Bind(attachments);
builder.Services.AddSingleton(attachments);
*/

// Third Way to register configuration ==> AttachmentsOptions (Prefered)
// You can Inject IOptionsInterface 
builder.Services.Configure<AttachmentsOptions>
    (builder.Configuration.GetSection("Attachments"));




var app = builder.Build();

// Configure the HTTP request pipelinr.

if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 
app.UseMiddleware<RateLimitingMiddleware>();

// NOTICE : The order for middleware is very important
app.UseMiddleware<ProfilingMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
