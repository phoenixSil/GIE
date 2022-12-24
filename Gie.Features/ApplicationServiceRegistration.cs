﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Gie.Features
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
