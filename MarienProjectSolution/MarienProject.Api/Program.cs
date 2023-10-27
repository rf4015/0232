using Serilog;
using MarienProject.Api.Repositories.Contracts;
using MarienProject.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MarienProject.Api.Models;
using MarienProject.Api.Services.Contracts;
using MarienProject.Api.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

builder.Services.AddDbContextPool<MarienPharmacyContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("MarienProjectConnection"))
);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

//JWt configuration
var privateKey = builder.Configuration.GetValue<string>("JwtSetting:PrivateKey");
var keybytes = Encoding.ASCII.GetBytes(privateKey);

builder.Services.AddAuthentication(config =>
{
	config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
	config.RequireHttpsMetadata = false;
	config.SaveToken = true;
	config.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(keybytes),
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateLifetime = true,
		ClockSkew = TimeSpan.Zero
	};
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
