using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Locations.Commands.Delete
{
    public class DeleteLocationHandler : IRequestHandler<DeleteLocation, Location>
    {
        private readonly IUnitOfWork uniteOfWorkRepo;

        public DeleteLocationHandler(IUnitOfWork uniteOfWorkRepo)
        {
            this.uniteOfWorkRepo = uniteOfWorkRepo;
        }

        public async Task<Location> Handle(DeleteLocation request, CancellationToken cancellationToken)
        {
            var location = await this.uniteOfWorkRepo.LocationRepository.GetByIdAsync(request.Id);

            if (!location.IsDeleted)
            {
                location.IsDeleted = true;
            }
            else
            {
                throw new InvalidOperationException("This location is already deleted");
            }

            return location;
        }
    }
}
