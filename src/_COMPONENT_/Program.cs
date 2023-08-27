using Application;
using Infrastructure;
using _COMPONENT_;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using _COMPONENT_.Helpers.HealthCheck;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureService();
builder.Services.AddComponentService(builder.Configuration, builder.Environment.EnvironmentName);
builder.Services.AddControllers();
builder.Services.AddHealthChecks()
    .AddCheck<AliveHealthCheck>("alive test 1234", tags: new[] { "alive test 1234" });

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
app.MapHealthChecks("/alive", new HealthCheckOptions
{
    //Predicate = healthCheck => healthCheck.Tags.Contains("ready"),
    ResponseWriter = HealthCheckAlive.WriteAsync,
});
app.MapControllers();
app.Run();
