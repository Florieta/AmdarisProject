using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCarSystem.Infrastructure.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Data.Configuration
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateUsers());
            //builder.HasMany(b => b.Bookings)
            //    .WithOne(u => u.ApplicationUser)
            //    .HasForeignKey(u => u.ApplicationUserId)
            //    .OnDelete(DeleteBehavior.Restrict);
            builder.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(l => l.LastName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(a => a.Address)
                .HasMaxLength(75);
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
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "admin123");

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                UserName = "Agent1",
                NormalizedUserName = "AGENT1",
                Email = "agent@mail.com",
                NormalizedEmail = "AGENT@GMAIL.COM",
                PhoneNumber = "1234567890",
                FirstName = "Peter",
                LastName = "Brown",
            };

            user.PasswordHash =
            hasher.HashPassword(user, "agent123");

            users.Add(user);

            return users;
        }
    }
    
}
