using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserManagement.Application.Common.Behaviours;

namespace UserManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            });

            return services;
        }

    }
}
