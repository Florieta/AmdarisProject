﻿using MediatR;
using RentACar.Domain.Entitites;
using RentACar.Domain.Entitites.Enum.Car;
using RentACar.Domain.Entitites.Enum.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Orders.Commands.Update
{
    public class UpdateOrder : IRequest<Order>
    {
        public int Id { get; set; }
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
