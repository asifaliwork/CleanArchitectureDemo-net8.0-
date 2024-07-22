using Application;
using Infrastructure;

namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services) 
        {
            services.AddAppDI()
                    .AddInfraDI();

            return services;
        }

    }
}
