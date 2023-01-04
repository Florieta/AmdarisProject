using AutoMapper;
using RentACar.Domain.Entitites;
using RentACar.WebApi.ViewModels.Rating;

namespace RentACar.WebApi.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, GetRatingViewModel>();
        }
    }
}
