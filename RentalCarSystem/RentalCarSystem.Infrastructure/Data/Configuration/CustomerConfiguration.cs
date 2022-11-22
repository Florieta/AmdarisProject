using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCarSystem.Infrastructure.Entities;
using RentalCarSystem.Infrastructure.Entities.Enum.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Data.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(CreateCustomers());

            builder.HasKey(i => i.Id);

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(75);
            builder.Property(a => a.Address)
                .IsRequired()
                .HasMaxLength(75);
            builder.Property(p => p.PhoneNumber)
               .IsRequired()
               .HasMaxLength(20);
            builder.Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(75);
            builder.Property(i => i.IdCardNumber)
              .IsRequired()
              .HasMaxLength(20);
            builder.Property(d => d.DriverLicenseNumber)
              .IsRequired()
              .HasMaxLength(20);
            builder.Property(d => d.DateOfExpired)
              .IsRequired();
            builder.Property(d => d.DateOfIssue)
            .IsRequired();
            builder.Property(i => i.IssuedBy)
            .IsRequired()
            .HasMaxLength(20);
            builder.Property(i => i.Gender)
            .IsRequired();
        }
        private List<Customer> CreateCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer()
                 {
                      Id = 1,
                      FullName = "John Snow",
                      Address = "Bulgaria, Sofia, Mladost 3, bl.222, ap.7",
                      Gender = Gender.Man,
                      PhoneNumber = "0888888887",
                      Email = "johns@mail.bg",
                      IdCardNumber = "12343567",
                      DriverLicenseNumber = "2222444567",
                      DateOfIssue = new DateTime(2016, 11, 17),
                      DateOfExpired = new DateTime(2026, 11, 17),
                      IssuedBy = "MVR Sofia"

                 },

                new Customer()
                 {
                      Id = 2,
                      FullName = "John Brown",
                      Address = "Bulgaria, Varna, ul.Pirin, bl.2, ap.3",
                      Gender = Gender.Man,
                      PhoneNumber = "0888222287",
                      Email = "johnb@gmail.com",
                      IdCardNumber = "12223567",
                      DriverLicenseNumber = "2134244567",
                      DateOfIssue = new DateTime(2011, 10, 22),
                      DateOfExpired = new DateTime(2021, 10, 22),
                      IssuedBy = "MVR Varna"

                 }
            };

            return customers;
        }
    }

}
