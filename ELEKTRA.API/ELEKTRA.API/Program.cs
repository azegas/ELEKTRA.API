using ELEKTRA.API.Interfaces;
using ELEKTRA.API.Services;
using ELEKTRA.DataAccess;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// TODO when creating calculations part - price value 0.22 try putting into record

// TODO Add services to the container.

builder.Services.AddControllers();

// injecting my first service!!! Can be AddSingleton, AddScoped, AddTransient
// Injecting it as interface
// Think of this as saying:
// "When a component asks for an IWelcomeService, provide an instance of WelcomeService."
builder.Services.AddScoped<IWelcomeService, WelcomeService>();

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
