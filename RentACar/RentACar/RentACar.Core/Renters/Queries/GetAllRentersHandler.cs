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
    public class GetAllRentersHandler : IRequestHandler<GetAllRenters, List<Renter>>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public GetAllRentersHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<List<Renter>> Handle(GetAllRenters request, CancellationToken cancellationToken)
        {
            return await this.unitOfWorkRepo.RenterRepository.GetAllAsync();
        }
    }
}
