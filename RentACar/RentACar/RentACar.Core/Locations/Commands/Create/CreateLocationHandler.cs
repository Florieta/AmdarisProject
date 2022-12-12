using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entitites;
using MediatR;
using RentACar.Application.Abstract;

namespace RentACar.Application.Locations.Commands.Create
{
    public class CreateLocationHandler : IRequestHandler<CreateLocation, Location>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public CreateLocationHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<Location> Handle(CreateLocation request, CancellationToken cancellationToken)
        {
            var location = new Location
            {
                LocationName = request.LocationName,
                Address = request.Address
            };

            await this.unitOfWorkRepo.LocationRepository.Add(location);
            await this.unitOfWorkRepo.Save();

            return location;
        }
    }
}
