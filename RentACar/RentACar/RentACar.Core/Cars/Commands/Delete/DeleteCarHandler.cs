using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Cars.Commands.Delete
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrder, Car>
    {
        private readonly IUnitOfWork uniteOfWorkRepo;

        public DeleteOrderHandler(IUnitOfWork uniteOfWorkRepo)
        {
            this.uniteOfWorkRepo = uniteOfWorkRepo;
        }

        public async Task<Car> Handle(DeleteOrder request, CancellationToken cancellationToken)
        {
            var car = await this.uniteOfWorkRepo.CarRepository.GetById(request.Id);

            if (!car.IsDeleted)
            {
                car.IsDeleted = true;
            }
            else
            {
                throw new InvalidOperationException("This car is already deleted");
            }

            return car;
        }
    }
}
