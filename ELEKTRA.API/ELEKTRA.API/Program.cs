﻿using Microsoft.EntityFrameworkCore;
using ELEKTRA.DataAccess;
using ELEKTRA.DataAccess.Extensions;


var builder = WebApplication.CreateBuilder(args);

// TODO when creating calculations part - price value 0.22 try putting into record

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration["ConnectionStrings:ELEKTRADB"];

builder.Services.AddDbContext<ElektraContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("ELEKTRADB") ??
    builder.Configuration.GetConnectionString("ELEKTRADB")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allowedOrigins = builder.Configuration.GetValue<string>("allowedOrigins")!.Split(",");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// TODO make automatic Update-Database like in ART/SEBRA

// **Run database initializer**
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ElektraContext>();
    DataSeeder.SeedData(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
