using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entitites;
using MediatR;
using RentACar.Application.Abstract;

namespace RentACar.Application.Cars.Commands.Create
{
    public class CreateLocationHandler : IRequestHandler<CreateCar, Car>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public CreateLocationHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<Car> Handle(CreateCar request, CancellationToken cancellationToken)
        {
            var car = new Car
            {
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
                DailyRate = request.DailyRate,
                DealerId = request.DealerId
            };

            await this.unitOfWorkRepo.CarRepository.AddAsync(car);
            await this.unitOfWorkRepo.SaveAsync();

            return car;
        }
    }
}
