using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Orders.Queries
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderById, Order>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public GetOrderByIdHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<Order> Handle(GetOrderById request, CancellationToken cancellationToken)
        {
            return await this.unitOfWorkRepo.OrderRepository.GetByIdAsync(request.Id);
        }
    }
}
