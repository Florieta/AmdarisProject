using RentACar.Domain.Entitites.Enum.Car;
using System.ComponentModel.DataAnnotations;

namespace RentACar.WebApi.ViewModels.Car
{
    public class AddCarModel
    {
        [Required]
        [StringLength(8, MinimumLength = 5)]
        public string RegNumber { get; set; } = null!;
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Model { get; set; } = null!;
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Make { get; set; } = null!;
        [Required]
        [Range(2015, 2023)]
        public int MakeYear { get; set; }

        public bool AirCondition { get; set; }
        public int Seats { get; set; }

        public int Doors { get; set; }

        public bool NavigationSystem { get; set; }

        public Fuel Fuel { get; set; }
        [Required]
        public string ImageUrl { get; set; } = null!;

        public Transmission Transmission { get; set; }
        [Required]

        public decimal DailyRate { get; set; }

        public int CategoryId { get; set; }

        public int DealerId { get; set; }
    }
}
