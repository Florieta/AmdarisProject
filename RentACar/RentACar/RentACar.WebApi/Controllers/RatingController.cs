using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Api.Logger;
using RentACar.Application.Ratings.Queries;
using RentACar.Domain.Entitites;
using RentACar.WebApi.ViewModels.Rating;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public RatingController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{carId}")]
        public async Task<IActionResult> GetByCarId(int carId)
        {
            Log.Instance.LogInformation("Retrieving the ratings by carId");

            GetRatingsByCarId query = new GetRatingsByCarId()
            {
                CarId = carId
            };

            List<Rating> result = await _mediator.Send(query);

            List<GetRatingViewModel> getRatingDto = _mapper.Map<List<GetRatingViewModel>>(result);
            return Ok(getRatingDto);
        }

    }
}
