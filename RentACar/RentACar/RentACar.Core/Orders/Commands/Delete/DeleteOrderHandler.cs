using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Orders.Commands.Delete
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrder, Order>
    {
        private readonly IUnitOfWork uniteOfWorkRepo;

        public DeleteOrderHandler(IUnitOfWork uniteOfWorkRepo)
        {
            this.uniteOfWorkRepo = uniteOfWorkRepo;
        }

        public async Task<Order> Handle(DeleteOrder request, CancellationToken cancellationToken)
        {
            var order = await this.uniteOfWorkRepo.OrderRepository.GetByIdAsync(request.Id);

            if (order.IsDeleted)
            {
                throw new InvalidOperationException("This order is already deleted");
            }

            this.uniteOfWorkRepo.OrderRepository.Remove(order);
            await this.uniteOfWorkRepo.SaveAsync();

            return order;
        }
    }
}
