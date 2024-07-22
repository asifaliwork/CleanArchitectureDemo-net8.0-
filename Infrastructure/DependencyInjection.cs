using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraDI(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-CH8SV7T; Database=CleanArchitectureApi; Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true");
            });

            services.AddScoped<IItemRepository, ItemRepository>();
            return services;
        }
    }
}
