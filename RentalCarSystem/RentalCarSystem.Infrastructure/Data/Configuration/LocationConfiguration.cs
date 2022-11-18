using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCarSystem.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Data.Configuration
{
    internal class LocationConfiguration : IEntityTypeConfiguration<Location>
    {

        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(CreateLocations());
            builder.HasMany(c => c.Cars);
            builder.HasMany(l => l.PickUpLocations);
            builder.HasMany(l => l.DropOffLocations);
            builder.Property(l => l.LocationName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Country)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(c => c.City)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(c => c.Street)
                .HasMaxLength(50);
            builder.Property(c => c.PostCode)
                .IsRequired()
                .HasMaxLength(10);
        }
        private List<Location> CreateLocations()
        {
            var locations = new List<Location>()
            {
                new Location()
                 {
                      Id = 1,
                      LocationName = "Varna Center",
                      Country = "Bulgaria",
                      City = "Varna",
                      PostCode = 9000
                 },

                new Location()
                {
                    Id = 2,
                    LocationName = "Varna Airport",
                      Country = "Bulgaria",
                      City = "Varna",
                      PostCode = 9000
                },

                new Location()
                {
                    Id = 3,
                   LocationName = "Sofia Airport",
                      Country = "Bulgaria",
                      City = "Sofia",
                      PostCode = 1000
                }
            };

            return locations;
        }
    }
}
