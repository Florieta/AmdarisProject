using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entitites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Data.Configuration
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateUsers());
           
            builder.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(l => l.LastName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(a => a.Address)
                .HasMaxLength(75);
            builder.Property(a => a.DrivingLicenseNumber)
                .HasMaxLength(10);
        }

        private List<ApplicationUser> CreateUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "d3211a8d-efde-4a19-8087-79cde4679276",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "1234567890",
                FirstName = "Peter",
                LastName = "Parker",
                IsDealer = true
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "admin123");

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                UserName = "User1",
                NormalizedUserName = "USER1",
                Email = "user@mail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                PhoneNumber = "1234567890",
                FirstName = "Peter",
                LastName = "Brown",
                IsDealer= false
            };

            user.PasswordHash =
            hasher.HashPassword(user, "user123");

            users.Add(user);

            return users;
        }
    }
}