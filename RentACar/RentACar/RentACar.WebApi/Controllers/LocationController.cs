using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Locations.Commands.Delete;
using RentACar.Application.Locations.Commands.Update;
using RentACar.Application.Locations.Commands.Create;
using RentACar.Application.Locations.Queries;
using RentACar.Domain.Entitites;
using RentACar.WebApi.ViewModels.Location;
using AutoMapper;
using MediatR;
using RentACar.WebApi.Middleware;
using RentACar.Api.Logger;

namespace RentACar.WebApi.Controllers
{
    [Route("api/Location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;
        public LocationController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            Log.Instance.LogInformation("Retrieving the list of locations");

            GetAllLocations query = new GetAllLocations();
            List<Location> result = await _mediator.Send(query);
            List<GetLocationViewModel> mappedResult = _mapper.Map<List<GetLocationViewModel>>(result);

            Log.Instance.LogInformation($"There are {result.Count} locations in the fleet");

            return Ok(mappedResult);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            GetLocationById query = new GetLocationById()
            {
                Id = Id
            };

            Log.Instance.LogInformation("Retrieving the location by Id");

            Location location = await _mediator.Send(query);

            if (location == null)
            {
                Log.Instance.LogWarning("The Id could not be found");
                return NotFound();
            }

            GetLocationViewModel getLocationModel = _mapper.Map<GetLocationViewModel>(location);
            return Ok(getLocationModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddLocationModel addLocationModel)
        {
            CreateLocation command = _mapper.Map<CreateLocation>(addLocationModel);
            Location location = await _mediator.Send(command);
            GetLocationViewModel getLocationModel = _mapper.Map<GetLocationViewModel>(location);

            Log.Instance.LogInformation($"A new {location.LocationName} was created  at {DateTime.Now.TimeOfDay}");

            return CreatedAtAction(nameof(GetById), new { locationId = location.Id }, getLocationModel);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit([FromBody] EditLocationViewModel editLocationModel, int locationId)
        {
            UpdateLocation command = _mapper.Map<UpdateLocation>(editLocationModel);

            command.Id = locationId;

            Log.Instance.LogInformation("Request with the updated location was sent!");

            Location location = await _mediator.Send(command);

            if (location == null)
            {
                return NotFound();
            }

            Log.Instance.LogInformation("The location was updated");

            return NoContent();
        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> Delete(int locationId)
        {
            DeleteLocation command = new DeleteLocation()
            {
                Id = locationId
            };

            try
            {
                Location location = await _mediator.Send(command);
                Log.Instance.LogInformation("A location was deleted from the list");
                if (location == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
