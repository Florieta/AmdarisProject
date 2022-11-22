using RentalCarSystem.Infrastructure.Entities.Enum.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string IdCardNumber { get; set; } = null!;

        public string DriverLicenseNumber { get; set; } = null!;

        public DateTime DateOfExpired { get; set; }
  
        public DateTime DateOfIssue { get; set; }
 
        public string IssuedBy { get; set; } = null!;

        public Gender Gender { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
