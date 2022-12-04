using RentACar.Infrastructure.Entitites.Enum.Car;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Car
{
    public class CarDetailsViewModel 
    {
        public int Id { get; set; }
        public string RegNumber { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int MakeYear { get; set; }

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = null!;

        [DisplayName("Price per day")]
        public decimal DailyRate { get; set; }
        public bool AirCondition { get; set; }
        public int Seats { get; set; }

        public int Doors { get; set; }

        public bool NavigationSystem { get; set; }

        public Fuel Fuel { get; set; }

        public Transmission Transmission { get; set; }

        public string CategoryName { get; set; } = null!;

        public bool IsAvailable { get; set; }

    }
}
