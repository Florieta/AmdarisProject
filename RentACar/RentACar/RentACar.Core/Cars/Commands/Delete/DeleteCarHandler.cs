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
    public class DeleteCarHandler : IRequestHandler<DeleteCar, Car>
    {
        private readonly IUnitOfWork uniteOfWorkRepo;

        public DeleteCarHandler(IUnitOfWork uniteOfWorkRepo)
        {
            this.uniteOfWorkRepo = uniteOfWorkRepo;
        }

        public async Task<Car> Handle(DeleteCar request, CancellationToken cancellationToken)
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
