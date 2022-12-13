using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Locations.Commands.Update
{
    public class UpdateLocationHandler : IRequestHandler<UpdateLocation, Location>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public UpdateLocationHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<Location> Handle(UpdateLocation request, CancellationToken cancellationToken)
        {
            var location = new Location()
            {
                Id = request.Id,
                LocationName = request.LocationName,
                Address = request.Address
            };

            await this.unitOfWorkRepo.LocationRepository.Update(location);
            await this.unitOfWorkRepo.SaveAsync();

            return location;
        }
    }
}
