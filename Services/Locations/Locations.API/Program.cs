using Locations.Core.Services;
using Locations.Core.Services.Interfaces;
using Locations.Infrastructure.Entities;
using Locations.Infrastructure.Repositories;
using Locations.Infrastructure.Repositories.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Locations.Core.Models;
using Locations.API.Consumers;

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

// Add services to the container.
builder.Services.AddMassTransit(config => {

    config.AddConsumer<PeopleAddressConsumer>();

    config.UsingRabbitMq((context, config) => {
        config.Host("amqp://guest:guest@localhost:5672");

        config.ReceiveEndpoint("people.address", c => {
            c.ConfigureConsumer<PeopleAddressConsumer>(context);
        });
    });
});

builder.Services.AddControllers();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration["Locations"];
builder.Services.AddDbContext<LocationsContext>(options => options.UseSqlServer(connectionString));

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
