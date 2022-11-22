using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCarSystem.Infrastructure.Entities;
using RentalCarSystem.Infrastructure.Entities.Enum.Booking;
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
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Car)
                .WithMany(b => b.Bookings)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Customer)
                 .WithMany(b => b.Bookings)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ApplicationUser)
                .WithMany(b => b.Bookings)
               .HasForeignKey(c => c.ApplicationUserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.PickUpLocation)
                 .WithMany(c => c.PickUpLocations)
                 .HasForeignKey(t => t.PickUpLocationId)
                 .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.DropOffLocation)
                 .WithMany(c => c.DropOffLocations)
                 .HasForeignKey(t => t.DropOffLocationId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Property(pd => pd.PickUpDateAndTime)
                .IsRequired();
            builder.Property(dd => dd.DropOffDateAndTime)
               .IsRequired();
            builder.Property(d => d.Duration)
               .IsRequired();
            builder.Property(a => a.TotalAmount)
               .IsRequired();
            builder.Property(a => a.PaymentType)
              .IsRequired();
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
                     PaymentType = PaymentType.Card,
                     CarId = 3,
                     CustomerId = 1,
                     PickUpLocationId = 1,
                     DropOffLocationId = 1,
                     InsuranceCode = 1,
                     TotalAmount = 292,
                     IsActive = true,
                     IsPaid = false,
                     IsRented = false,
                     ApplicationUserId = "d3211a8d-efde-4a19-8087-79cde4679276"
                },
                new Booking()
                {
                     Id = 2,
                     PickUpDateAndTime = new DateTime(2022, 11, 17, 3, 0, 0),
                     DropOffDateAndTime = new DateTime(2022, 11, 20, 5, 0, 0),
                     Duration = 3,
                     PaymentType = PaymentType.BankTransfer,
                     CarId = 2,
                     CustomerId = 2,
                     PickUpLocationId = 1,
                     DropOffLocationId = 2,
                     InsuranceCode = 2,
                     TotalAmount = 114,
                     IsActive = true,
                     IsPaid = false,
                     IsRented = false,
                     ApplicationUserId = "d3211a8d-efde-4a19-8087-79cde4679276"
                }
            };

            return bookings;
        }
    }
}

