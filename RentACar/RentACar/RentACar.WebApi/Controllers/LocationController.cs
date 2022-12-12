using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Locations.Commands.Create;
using RentACar.Application.Locations.Queries;
using RentACar.Domain.Entitites;
using RentACar.WebApi.ViewModels.Location;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : BaseController<LocationController>
    {
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            GetAllLocations query = new GetAllLocations();
            List<Location> result = await base.Mediator.Send(query);
            List<GetLocationViewModel> mappedResult = base.Mapper.Map<List<GetLocationViewModel>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("GetById/{locationId}")]
        public async Task<IActionResult> GetById(int locationId)
        {
            GetLocationById query = new GetLocationById()
            {
                Id = locationId
            };

            Location location = await base.Mediator.Send(query);

            if (location == null)
            {
                return NotFound();
            }

            GetLocationViewModel getLocationModel = base.Mapper.Map<GetLocationViewModel>(location);
            return Ok(getLocationModel);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddLocationModel addLocationModel)
        {
            CreateLocation command = base.Mapper.Map<CreateLocation>(addLocationModel);
            Location location = await base.Mediator.Send(command);
            GetLocationViewModel getLocationModel = base.Mapper.Map<GetLocationViewModel>(location);
            return CreatedAtAction(nameof(GetById), new { locationId = location.Id }, getLocationModel);
        }

    }
}
