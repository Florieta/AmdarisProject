using Microsoft.EntityFrameworkCore;
using RentACar.Application.Abstract;
using RentACar.Infrastructure.Data;
using RentACar.Infrastructure.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RentalACarApiServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            //services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
