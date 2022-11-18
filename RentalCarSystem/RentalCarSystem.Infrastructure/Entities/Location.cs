using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarSystem.Infrastructure.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(50)]
        public string LocationName { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Country { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string City { get; set; } = null!;
        
        [MaxLength(50)]
        public string? Street { get; set; } 

        [Required]
        [MaxLength(10)]
        public int PostCode { get; set; }

        [InverseProperty("PickUpLocation")]
        public ICollection<Booking> PickUpLocations { get; set; } = new List<Booking>();

        [InverseProperty("DropOffLocation")]
        public ICollection<Booking> DropOffLocations { get; set; } = new List<Booking>();

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
