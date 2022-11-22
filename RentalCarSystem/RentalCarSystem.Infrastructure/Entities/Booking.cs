using RentalCarSystem.Infrastructure.Entities.Enum.Booking;
using RentalCarSystem.Infrastructure.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Entities
{
    public class Booking
    {
        public int Id { get; set; } 

        public DateTime PickUpDateAndTime { get; set; } 

        public DateTime DropOffDateAndTime { get; set; } 

        public int Duration { get; set; }

        public decimal TotalAmount { get; set; }

        public PaymentType PaymentType { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsPaid { get; set; } = false;

        public bool IsRented { get; set; } = false;

        public int CarId { get; set; }

        public Car Car { get; set; } = null!;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int PickUpLocationId { get; set; }

        public Location PickUpLocation { get; set; } = null!;

        public int DropOffLocationId { get; set; }

        public Location DropOffLocation { get; set; } = null!;

        public int InsuranceCode { get; set; }

        public Insurance? Insurance { get; set; }

        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
