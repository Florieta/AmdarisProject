using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Entities
{
    public class Insurance
    {
        [Key]
        public int InsuranceCode { get; set; }

        [Required]
        [StringLength(20)]
        public string TypeOfInsurance { get; set; } = null!;

        [Required]
        public decimal CostPerDay { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
