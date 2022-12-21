using RentACar.Domain.Entitites;
using RentACar.Domain.Entitites.Enum.Car;

namespace RentACar.WebApi.ViewModels.Car
{
    public class GetCarViewModel
    {
        public int Id { get; set; }
        public string RegNumber { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Make { get; set; } = null!;
        public int MakeYear { get; set; }

        public bool AirCondition { get; set; }
        public int Seats { get; set; }

        public int Doors { get; set; }

        public bool NavigationSystem { get; set; }

        public Fuel Fuel { get; set; }

        public string ImageUrl { get; set; } = null!;

        public Transmission Transmission { get; set; }

        public decimal DailyRate { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string CategoryName { get; set; } = null!;

    }
}
