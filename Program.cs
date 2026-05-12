using Microsoft.EntityFrameworkCore;
using MyHabitsApi.Context;
using MyHabitsApi.Extentions;
using MyHabitsApi.Filters;
using MyHabitsApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFilter));
}).AddNewtonsoftJson();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAuthentication("Nearer").AddJwtBearer();
var mySqlConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<ApiDbContext>(options => options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));
builder.Services.AddAutoMapper(typeof(ApiMappingDTOProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
