using RentalCarSystem.Infrastructure.Entities.Enum.Booking;
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
        [Key]
        public int Id { get; set; } 

        [Required]
        public DateTime PickUpDateAndTime { get; set; } 

        [Required]
        public DateTime DropOffDateAndTime { get; set; } 

        [Required]
        public int Duration { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(PickUpLocation))]
        public int PickUpLocationId { get; set; }

        public Location PickUpLocation { get; set; } = null!;

        [ForeignKey(nameof(DropOffLocation))]
        public int DropOffLocationId { get; set; }

        public Location DropOffLocation { get; set; } = null!;

        [ForeignKey(nameof(Insurance))]
        public int InsuranceCode { get; set; }

        public Insurance? Insurance { get; set; }

        public ICollection<UserBooking> UsersBookings { get; set; } = new List<UserBooking>();


    }
}
