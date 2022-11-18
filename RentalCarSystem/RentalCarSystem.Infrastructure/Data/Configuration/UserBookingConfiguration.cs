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
    internal class UserBookingConfiguration : IEntityTypeConfiguration<UserBooking>
    {

        public void Configure(EntityTypeBuilder<UserBooking> builder)
        {
            builder.HasData(CreateUsersBookings());

            builder.HasKey(x => new { x.ApplicationUserId, x.BookingId });
            builder.Property(x => x.ApplicationUserId).IsRequired();
            builder.Property(x => x.BookingId).IsRequired();
        }
        private List<UserBooking> CreateUsersBookings()
        {
            var usersBookings = new List<UserBooking>()
            {
                new UserBooking()
                 {
                      ApplicationUserId = "d3211a8d-efde-4a19-8087-79cde4679276",
                      BookingId = 1
                 },

                new UserBooking()
                {
                    ApplicationUserId = "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                    BookingId = 2
                },

                
            };

            return usersBookings;
        }

    }
}
