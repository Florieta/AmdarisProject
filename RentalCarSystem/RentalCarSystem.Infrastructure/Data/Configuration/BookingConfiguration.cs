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
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {

        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(CreateBookings());
        }

        private List<Booking> CreateBookings()
        {
            var bookings = new List<Booking>()
            {
                new Booking()
                {
                     Id = 1,
                     PickUpDateAndTime = new DateTime(2022, 11, 17, 5, 0, 0),
                     DropOffDateAndTime = new DateTime(2022, 11, 23, 6, 0, 0),
                     Duration = 6,
                     PaymentType = 0,
                     CarId = 3,
                     CustomerId = 1,
                     PickUpLocationId = 1,
                     DropOffLocationId = 1,
                     InsuranceCode = 1,
                     TotalAmount = 292
                },
                new Booking()
                {
                     Id = 2,
                     PickUpDateAndTime = new DateTime(2022, 11, 17, 3, 0, 0),
                     DropOffDateAndTime = new DateTime(2022, 11, 20, 5, 0, 0),
                     Duration = 3,
                     PaymentType = 0,
                     CarId = 2,
                     CustomerId = 2,
                     PickUpLocationId = 1,
                     DropOffLocationId = 2,
                     InsuranceCode = 2,
                     TotalAmount = 114
                }
            };

            return bookings;
        }
    }
}

