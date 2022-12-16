using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Renters.Queries
{
    public class GetRenterByIdHandler : IRequestHandler<GetRenterById, Renter>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public GetRenterByIdHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<Renter> Handle(GetRenterById request, CancellationToken cancellationToken)
        {
            return await this.unitOfWorkRepo.RenterRepository.GetByIdAsync(request.Id);
        }
    }
}
