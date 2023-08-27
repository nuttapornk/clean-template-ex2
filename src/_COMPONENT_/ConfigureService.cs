using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _COMPONENT_;

public static class ConfigureService
{
    public static IServiceCollection AddComponentService(this IServiceCollection service,
    IConfiguration configuration, string environmentName)
    {
        service.AddHttpContextAccessor();
        service.AddCors(options =>
        {
            options.AddPolicy("CORS", policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
            });
        });


        return service;
    }
}
