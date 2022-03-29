using Microsoft.EntityFrameworkCore;
using ReferenceData.Core.Services;
using ReferenceData.Core.Services.Interfaces;
using ReferenceData.Infrastructure.Entities;
using ReferenceData.Infrastructure.Repositories;
using ReferenceData.Infrastructure.Repositories.Interfaces;

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
builder.Services.AddTransient<IRefDataRepository, RefDataRepository>();
builder.Services.AddTransient<IRefDataService, RefDataService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration["RefData"];
builder.Services.AddDbContext<RefDataContext>(options => options.UseSqlServer(connectionString));
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

app.UseCors(siteCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
