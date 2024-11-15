using Application.Abstractions.Repositories;
using Application.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            //Add other libraries dependency here
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
