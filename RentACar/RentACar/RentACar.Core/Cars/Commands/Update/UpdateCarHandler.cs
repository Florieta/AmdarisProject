using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Cars.Commands.Update
{
    public class UpdateCarHandler : IRequestHandler<UpdateCar, Car>
    {
        private readonly IUnitOfWork uniteOfWorkRepo;

        public UpdateCarHandler(IUnitOfWork uniteOfWorkRepo)
        {
            this.uniteOfWorkRepo = uniteOfWorkRepo;
        }

        public async Task<Car> Handle(UpdateCar request, CancellationToken cancellationToken)
        {
            var car = new Car
            {
                Id = request.Id,
                RegNumber = request.RegNumber,
                Make = request.Make,
                Model = request.Model,
                MakeYear = request.MakeYear,
                ImageUrl = request.ImageUrl,
                AirCondition = request.AirCondition,
                Seats = request.Seats,
                Doors = request.Doors,
                NavigationSystem = request.NavigationSystem,
                Fuel = request.Fuel,
                Transmission = request.Transmission,
                CategoryId = request.CategoryId,
                DealerId = request.DealerId
            };

            await this.uniteOfWorkRepo.CarRepository.Update(car);
            await this.uniteOfWorkRepo.SaveAsync();

            return car;
        }
    }
}
