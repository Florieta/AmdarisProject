﻿using RentACar.Domain.Entitites.Enum.Order;

namespace RentACar.WebApi.ViewModels.Order
{
    public class AddOrderDto
    {
        public DateTime PickUpDateAndTime { get; set; }

        public DateTime DropOffDateAndTime { get; set; }

        public int Duration { get; set; }

        public decimal TotalAmount { get; set; }

        public PaymentType PaymentType { get; set; }

        public bool IsPaid { get; set; } = false;

        public int CarId { get; set; }

        public int PickUpLocationId { get; set; }

        public int DropOffLocationId { get; set; }

        public int InsuranceCode { get; set; }

    }
}