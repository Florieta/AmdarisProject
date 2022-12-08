using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Cars.Queries
{
    public class GetAllCarsHandler : IRequestHandler<GetAllCars, List<Car>>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public GetAllCarsHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<List<Car>> Handle(GetAllCars request, CancellationToken cancellationToken)
        {
            return await this.unitOfWorkRepo.CarRepository.GetAll();
        }
    }
}
