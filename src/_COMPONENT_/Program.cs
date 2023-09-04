using Application;
using Infrastructure;
using _COMPONENT_;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using _COMPONENT_.Helpers.HealthCheck;
using _COMPONENT_.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddComponentService(builder.Configuration, builder.Environment.EnvironmentName);
builder.Services.AddControllers();

var app = builder.Build();

//Middleware
app.UseMiddleware<RequestHeaderMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
    app.UseReDoc();
}
app.UseCors("CORS");

//HealtCheck
app.UseHealthChecks("/health");
app.MapHealthChecks("/alive", new HealthCheckOptions
{
    //Predicate = healthCheck => healthCheck.Tags.Contains("ready"),
    ResponseWriter = HealthCheckAlive.WriteAsync,
});
app.MapControllers();
app.Run();

namespace _COMPONENT_
{
    public partial class Program { }
}