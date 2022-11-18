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
        }

        private List<ApplicationUser> CreateUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "d3211a8d-efde-4a19-8087-79cde4679276",
                UserName = "Agent1",
                NormalizedUserName = "AGENT1",
                Email = "agent@mail.com",
                NormalizedEmail = "AGENT@GMAIL.COM",
                FirstName = "Peter",
                LastName = "Parker",
                JobPosition = "Agent"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "agent123");

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                UserName = "Agent2",
                NormalizedUserName = "AGENT2",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@GMAIL.COM",
                FirstName = "Peter",
                LastName = "Brown",
                JobPosition = "Agent"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "guest123");

            users.Add(user);

            return users;
        }
    }
    
}
