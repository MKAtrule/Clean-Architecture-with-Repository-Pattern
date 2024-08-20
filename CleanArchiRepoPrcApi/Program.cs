using Application.Interface;
using Application.Mappers.ProductMap;
using CleanArchiRepoPrcApi.Common.Services;
using Infrastructure.Config;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
ServiceConfiguration.Configuration(builder.Services);
builder.Services.AddDbContext<ApplicationDBcontext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
b=>b.MigrationsAssembly("Infrastructure")));
builder.Services.AddAutoMapper(typeof(CategoryProfile));
builder.Services.AddSingleton<IHostEnvironmentService,HostEnvironmentService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
