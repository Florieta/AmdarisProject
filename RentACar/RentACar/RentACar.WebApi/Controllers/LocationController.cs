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

namespace RentACar.WebApi.Controllers
{
    [Route("api/Location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;
        private readonly ILogger<CarController> _logger;
        public LocationController(IMapper mapper, IMediator mediator, ILogger<CarController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            _logger.LogInformation("Retrieving the list of locations"); 

            GetAllLocations query = new GetAllLocations();
            List<Location> result = await _mediator.Send(query);
            List<GetLocationViewModel> mappedResult = _mapper.Map<List<GetLocationViewModel>>(result);

            _logger.LogInformation($"There are {result.Count} locations in the fleet"); 

            return Ok(mappedResult);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            GetLocationById query = new GetLocationById()
            {
                Id = Id
            }; 
            
            _logger.LogInformation("Retrieving the location by Id"); 

            Location location = await _mediator.Send(query);

            if (location == null)
            {
                _logger.LogWarning("The Id could not be found");
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

            _logger.LogInformation($"A new {location.LocationName} was created  at {DateTime.Now.TimeOfDay}");

            return CreatedAtAction(nameof(GetById), new { locationId = location.Id }, getLocationModel);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit([FromBody] EditLocationVideModel editLocationModel, int locationId)
        {
            UpdateLocation command = _mapper.Map<UpdateLocation>(editLocationModel);

            command.Id = locationId;

            _logger.LogInformation("Request with the updated location was sent!");

            Location location = await _mediator.Send(command);

            if (location == null)
            {
                return NotFound();
            }

            _logger.LogInformation("The location was updated");

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
                _logger.LogInformation("A location was deleted from the list");
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
