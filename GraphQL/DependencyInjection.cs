using Application;
using Infrastructure;

namespace GraphQL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGraphQlDI(this IServiceCollection services) 
        {
            services.AddAppDI()
                    .AddInfraDI();

            return services;
        }

    }
}
