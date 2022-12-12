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
    public class GetCarByIdHandler : IRequestHandler<GetCarById, Car>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public GetCarByIdHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<Car> Handle(GetCarById request, CancellationToken cancellationToken)
        {
            return await this.unitOfWorkRepo.CarRepository.GetByIdAsync(request.Id);
        }
    }
}
