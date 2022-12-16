using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Orders.Commands.Update
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrder, Order>
    {
        private readonly IUnitOfWork uniteOfWorkRepo;

        public UpdateOrderHandler(IUnitOfWork uniteOfWorkRepo)
        {
            this.uniteOfWorkRepo = uniteOfWorkRepo;
        }

        public async Task<Order> Handle(UpdateOrder request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = request.Id,
                PickUpDateAndTime = request.PickUpDateAndTime,
                DropOffDateAndTime = request.DropOffDateAndTime,
                Duration = request.Duration,
                TotalAmount = request.TotalAmount,
                PaymentType = request.PaymentType,
                IsPaid = request.IsPaid,
                CarId = request.CarId,
                PickUpLocationId = request.PickUpLocationId,
                DropOffLocationId = request.DropOffLocationId,
                Insurance = request.Insurance,
                RenterId = request.RenterId
            };

            await this.uniteOfWorkRepo.OrderRepository.Update(order);
            await this.uniteOfWorkRepo.SaveAsync();

            return order;
        }
    }
}
