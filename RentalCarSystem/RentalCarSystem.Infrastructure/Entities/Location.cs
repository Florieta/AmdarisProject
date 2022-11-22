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
        public int Id { get; set; } 
        public string LocationName { get; set; } = null!;

        public string Address { get; set; } = null!;

        [InverseProperty("PickUpLocation")]
        public ICollection<Booking> PickUpLocations { get; set; } = new List<Booking>();

        [InverseProperty("DropOffLocation")]
        public ICollection<Booking> DropOffLocations { get; set; } = new List<Booking>();

    }
}
