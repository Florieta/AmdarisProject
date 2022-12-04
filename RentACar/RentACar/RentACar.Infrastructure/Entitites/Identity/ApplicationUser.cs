using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Entitites.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Address { get; set; }
        public string? DrivingLicenseNumber { get; set; } = null!;
        public bool IsDealer { get; set; } = false;

        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
