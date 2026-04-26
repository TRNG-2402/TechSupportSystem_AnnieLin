using Microsoft.EntityFrameworkCore;
using TechSupportSystemWeb.Data;
using TechSupportSystemWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); // Adding Swagger
builder.Services.AddDbContext<SupportSystemDbContext>(options =>
    options.UseSqlite("Data Source=techsupport.db")
);
builder.Services.AddScoped<ISupportService, SupportService>();
builder.Services.AddScoped<ISupportTicketRepo, SupportTicketRepo>();

builder.Services.AddScoped<ITechnicianService, TechnicianService>();
builder.Services.AddScoped<ITechnicianRepo, TechnicianRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//Adding Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Serves the JSON at /swagger/v1/swagger.json
    app.UseSwaggerUI(); // Serves the UI at /swagger
}

app.UseAuthorization();

app.MapControllers();

app.Run();
