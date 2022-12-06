using RentACar.Core.CustomAttribute;
using RentACar.Infrastructure.Entitites;
using RentACar.Infrastructure.Entitites.Enum.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.ViewModels.Booking
{
    public class OrderFormViewModel
    {

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PickUpDateAndTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [IsDateAfterAttribute("PickUpDateAndTime", true, ErrorMessage = "The droff off date should be after the pick up date!")]
        public DateTime DropOffDateAndTime { get; set; }

        [Required]
        public int Duration { get; set; }

        public int PickUpLocationId { get; set; }

        public IEnumerable<Location> PickUpLocations { get; set; } = new List<Location>();
        public int DropOffLocationId { get; set; }
        public IEnumerable<Location> DropOffLocations { get; set; } = new List<Location>();
        public int InsuranceCode { get; set; }

        public IEnumerable<Insurance> Insurance { get; set; } = new List<Insurance>();

        public decimal DailyRate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        public bool IsActive { get; set; }

        public bool IsPaid { get; set; }
    }
}
