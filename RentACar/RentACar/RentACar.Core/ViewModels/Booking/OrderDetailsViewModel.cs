using RentACar.Infrastructure.Entitites.Enum.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.ViewModels.Booking
{
    public class OrderDetailsViewModel
    {
        //Car
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string RegNumber { get; set; } = null!;

        public int MakeYear { get; set; }

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = null!;

        //User
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string DrivingLicenseNumber { get; set; } = null!;
        //Order
        public DateTime PickUpDateAndTime { get; set; }

        public DateTime DropOffDateAndTime { get; set; }

        public int Duration { get; set; }

        public string PickUpLocationName { get; set; } = null!;

        public string DropOffLocationName { get; set; } = null!;

        public decimal TotalAmount { get; set; }

        public PaymentType PaymentType { get; set; } 
    }
}
