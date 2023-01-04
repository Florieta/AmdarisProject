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
    public class DeleteRatingHandler : IRequestHandler<DeleteRating, Car>
    {
        private readonly IUnitOfWork uniteOfWorkRepo;

        public DeleteRatingHandler(IUnitOfWork uniteOfWorkRepo)
        {
            this.uniteOfWorkRepo = uniteOfWorkRepo;
        }

        public async Task<Car> Handle(DeleteRating request, CancellationToken cancellationToken)
        {
            var car = await this.uniteOfWorkRepo.CarRepository.GetByIdAsync(request.Id);

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
