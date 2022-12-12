using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Locations.Queries
{
    public class GetLocationByIdHandler : IRequestHandler<GetLocationById, Location>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public GetLocationByIdHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<Location> Handle(GetLocationById request, CancellationToken cancellationToken)
        {
            return await this.unitOfWorkRepo.LocationRepository.GetById(request.Id);
        }
    }
}
