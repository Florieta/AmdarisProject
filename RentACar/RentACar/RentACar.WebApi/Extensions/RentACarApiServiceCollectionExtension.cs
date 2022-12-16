using Microsoft.EntityFrameworkCore;
using RentACar.Application;
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
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IDealerRepository, DealerRepository>();
            services.AddScoped<IRenterRepository, RenterRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            //services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
