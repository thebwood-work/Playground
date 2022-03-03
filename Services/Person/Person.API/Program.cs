using Microsoft.EntityFrameworkCore;
using Person.Core.Services;
using Person.Core.Services.Interfaces;
using Person.Infrastructure.Entities;
using Person.Infrastructure.Repositories;
using Person.Infrastructure.Repositories.Interfaces;

var siteCorsPolicy = "SiteCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: siteCorsPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:5253", "http://localhost:3000", "http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
        });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration["Person"];
builder.Services.AddDbContext<PersonContext>(options => options.UseSqlServer(connectionString));

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
