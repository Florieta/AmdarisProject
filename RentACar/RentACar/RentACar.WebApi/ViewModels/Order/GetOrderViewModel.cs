using RentACar.Domain.Entitites.Enum.Order;

namespace RentACar.WebApi.ViewModels.Order
{
    public class GetOrderViewModel
    {
        public DateTime PickUpDateAndTime { get; set; }

        public DateTime DropOffDateAndTime { get; set; }

        public int Duration { get; set; }

        public decimal TotalAmount { get; set; }

        public PaymentType PaymentType { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsPaid { get; set; } = false;

        public string CarMake { get; set; } = null!;

        public string CarModel { get; set; } = null!;

        public string RegNumber { get; set; } = null!;

        public string PickUpLocation { get; set; } = null!;


        public string DropOffLocation { get; set; } = null!;

        public string? Insurance { get; set; }

        public string Renter { get; set; } = null!;

    }
}
