using RentACar.Infrastructure.Entitites;
using RentACar.Infrastructure.Entitites.Enum.Car;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Models.Car
{
    public class CreateCarInputModel
    {

        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Make { get; set; } = null!;

        [Required]
        public int MakeYear { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 6)]
        public string RegNumber { get; set; } = null!;

        [Required]
        public decimal DailyRate { get; set; }


        public bool AirCondition { get; set; }
        public int Seats { get; set; }

        public int Doors { get; set; }

        public bool NavigationSystem { get; set; }

        public Fuel Fuel { get; set; }

        public Transmission Transmission { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public string ApplicationUserId { get; set; } = null!;

    }
}
