using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalCarSystem.Infrastructure.Data.Configuration;
using RentalCarSystem.Infrastructure.Entities;
using RentalCarSystem.Infrastructure.Entities.Identity;

namespace RentalCarManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Booking> Bookings { get; init; } = null!;

        public DbSet<Car> Cars { get; init; } = null!;

        public DbSet<Category> Categories { get; init; } = null!;

        public DbSet<Customer> Customers { get; init; } = null!;

        public DbSet<Location> Locations { get; init; } = null!;

        public DbSet<Insurance> Insurances { get; init; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new BookingConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new InsuranceConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}