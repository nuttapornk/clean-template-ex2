using Application;
using Infrastructure;
using _COMPONENT_;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureService();
builder.Services.AddComponentService(builder.Configuration, builder.Environment.EnvironmentName);
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddOpenApiDocument();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
    app.UseReDoc();
}
app.UseCors("CORS");
app.UseHealthChecks("/health");
app.MapControllers();
app.Run();
