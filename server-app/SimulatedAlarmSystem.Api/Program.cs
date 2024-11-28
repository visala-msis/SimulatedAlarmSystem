using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SimulatedAlarmSystem.Api.Hubs;
using SimulatedAlarmSystem.BL.Interfaces;
using SimulatedAlarmSystem.Models;
using SimulatedAlarmSystem.BL.Services;
using SimulatedAlarmSystem.Bl.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();

// Configure JWT authentication
builder.Services.AddAuthentication(options =>
	{
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	})
	.AddJwtBearer(options =>
	{
		options.RequireHttpsMetadata = false; // Set to true in production
		options.Authority = "https://your-auth-server"; // Replace with your auth server URL
		options.Audience = "your-api"; // Replace with your API audience
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidIssuer = "your-issuer", // Replace with your issuer
			ValidAudience = "your-api",  // Replace with your audience
			ClockSkew = TimeSpan.Zero // Optional: adjust for token expiration buffer
		};
	});

// Add Dependency Injection for AlarmService and XmlDataService
builder.Services.AddSingleton<IAlarmDataService, XmlDataService>();
builder.Services.AddSingleton<IAlarmService, AlarmService>();
builder.Services.AddSingleton<IUserService, UserService>();
// Add Dependency Injection for TokenService and other services
builder.Services.AddSingleton<ITokenService, TokenService>();

// Add configuration (appsettings.json)
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure CORS policy
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAngularApp", policy =>
	{
		policy.WithOrigins("http://localhost:4200") // Angular app origin
			.AllowAnyHeader()                   // Allow any HTTP headers
			.AllowAnyMethod();                  // Allow any HTTP methods (GET, POST, etc.)
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS policy
app.UseCors("AllowAngularApp");

app.UseAuthorization();

// Map controllers
app.MapControllers();

// Map SignalR hubs (including AlarmHub)
app.MapHub<AlarmHub>("/alarmHub");

app.Run();