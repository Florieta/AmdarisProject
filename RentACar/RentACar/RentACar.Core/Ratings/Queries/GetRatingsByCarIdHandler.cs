using MediatR;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Ratings.Queries
{
    public class GetRatingsByCarIdHandler : IRequestHandler<GetRatingsByCarId, List<Rating>>
    {
        private readonly IUnitOfWork unitOfWorkRepo;

        public GetRatingsByCarIdHandler(IUnitOfWork unitOfWorkRepo)
        {
            this.unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<List<Rating>> Handle(GetRatingsByCarId request, CancellationToken cancellationToken)
        {
            return await this.unitOfWorkRepo.RatingRepository.GetAllAsyncByCarId(request.CarId);
        }
    }
}
