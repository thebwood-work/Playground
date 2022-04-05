using IdentityAndSecurity.Core.Services;
using IdentityAndSecurity.Core.Services.Interfaces;
using IdentityAndSecurity.Infrastructure.Entities;
using IdentityAndSecurity.Infrastructure.Repositories;
using IdentityAndSecurity.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var siteCorsPolicy = "SiteCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: siteCorsPolicy,
        builder =>
        {
            builder.WithOrigins("https://localhost:5010")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
        });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<IIdentityAndSecurityRepository, IdentityAndSecurityRepository>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IAuthorizationService, AuthorizationService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration["IdentityAndSecurity"];
builder.Services.AddDbContext<IdentityAndSecurityContext>(options => options.UseSqlServer(connectionString));


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
app.UseCors(siteCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
