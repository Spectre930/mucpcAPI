using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using mucpc.Application.Extensions;
using mucpc.Infrastructure.Extension;
using mucpc.Infrastructure.Seeders;
using mucpc.Infrastructure.Seeders.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection("Gmail"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("JWT:Key").Value!))
        };
    });

//register services
builder.Services.AddApplication();
//register DbContext
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();

// Seed the database
var scope = app.Services.CreateScope();
var roleseeder = scope.ServiceProvider.GetRequiredService<IRoleSeeder>();
var adminseeder = scope.ServiceProvider.GetRequiredService<mucpc.Infrastructure.Seeders.interfaces.IAdminSeeder>();
await roleseeder.Seed();
await adminseeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
