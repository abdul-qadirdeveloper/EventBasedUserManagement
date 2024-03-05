using System.Text.Json.Serialization;

namespace UserManagement.ConsumerApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });



            return services;
        }
    }
}
