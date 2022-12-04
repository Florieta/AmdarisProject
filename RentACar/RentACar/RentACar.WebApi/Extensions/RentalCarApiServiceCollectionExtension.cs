using Microsoft.EntityFrameworkCore;
using RentACar.Core.Contracts;
using RentACar.Core.Services;
using RentACar.Infrastructure.Data;
using RentACar.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RentalACarApiServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IDealerService, DealerService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
