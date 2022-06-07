using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TiendaApp_Backend.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TiendaApp_BackendContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaApp_BackendContext") ?? throw new InvalidOperationException("Connection string 'TiendaApp_BackendContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services cors
builder.Services.AddCors(p => p.AddPolicy("CorsApp", builder =>
{
    builder.WithOrigins("https://localhost:44312/api").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// App cors
app.UseCors("CorsApp");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
