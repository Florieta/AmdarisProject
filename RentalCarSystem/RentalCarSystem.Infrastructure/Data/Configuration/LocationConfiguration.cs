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
