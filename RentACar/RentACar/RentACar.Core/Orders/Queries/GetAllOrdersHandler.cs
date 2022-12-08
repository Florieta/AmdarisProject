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
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrders, List<Order>>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public GetAllOrdersHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<List<Order>> Handle(GetAllOrders request, CancellationToken cancellationToken)
        {
            return await this.unitOfWorkRepo.OrderRepository.GetAll();
        }
    }
}
