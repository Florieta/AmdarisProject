using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entitites;
using MediatR;
using RentACar.Application.Abstract;

namespace RentACar.Application.Orders.Commands.Create
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder, Order>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public CreateOrderHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<Order> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                PickUpDateAndTime = request.PickUpDateAndTime,
                DropOffDateAndTime = request.DropOffDateAndTime,
                Duration = request.Duration,
                TotalAmount = request.TotalAmount,
                PaymentType = request.PaymentType,
                IsPaid = request.IsPaid,
                CarId = request.CarId,
                PickUpLocationId = request.PickUpLocationId,
                DropOffLocationId = request.DropOffLocationId,
                InsuranceCode = request.InsuranceCode
            };

            await this.unitOfWorkRepo.OrderRepository.Add(order);
            await this.unitOfWorkRepo.Save();

            return order;
        }
    }
}
