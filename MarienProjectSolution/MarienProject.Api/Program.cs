using Serilog;
using MarienProject.Api.Repositories.Contracts;
using MarienProject.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MarienProject.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add the service to the container
Log.Logger = new LoggerConfiguration()
			.ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<DbFarmaciaContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("MarienProjectConnection"))
);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
//You need to change from this to your localhost and ports, CHANGE THIS PLEASE. <<- HEy HEy Hey You.
app.UseCors(policy => policy
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.WithHeaders(HeaderNames.ContentType)
);
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
