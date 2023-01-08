﻿using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Cars.Queries
{
    public class GetAllCarsByDealerIdHandler : IRequestHandler<GetAllCarsByDealerId, List<Car>>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public GetAllCarsByDealerIdHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<List<Car>> Handle(GetAllCarsByDealerId request, CancellationToken cancellationToken)
        {
            return await this.unitOfWorkRepo.CarRepository.GetCarsByDealerIdAsync(request.DealerId);
        }
    }
}
