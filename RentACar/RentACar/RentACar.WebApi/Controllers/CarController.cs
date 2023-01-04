using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
using RentACar.Application.Cars.Queries;
using RentACar.Domain.Entitites;
using RentACar.WebApi.ViewModels.Car;
using RentACar.Application.Cars.Commands.Create;
using RentACar.Application.Cars.Commands.Update;
using RentACar.Application.Cars.Commands.Delete;
using RentACar.Application.Cars.Commands.Add;
using AutoMapper;
using MediatR;
using RentACar.Api.Logger;

namespace RentACar.WebApi.Controllers
{
    [Route("api/Car")]
    [ApiController]

    public class CarController : ControllerBase
    {

        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public CarController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            Log.Instance.LogInformation("Retrieving the list of cars");

            GetAllCars query = new GetAllCars();
            List<Car> result = await _mediator.Send(query);
            List<GetCarViewModel> mappedResult = _mapper.Map<List<GetCarViewModel>>(result);

           Log.Instance.LogInformation($"There are {result.Count} cars in the fleet");

            return Ok(mappedResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Instance.LogInformation("Retrieving the car by Id");

            GetCarById query = new GetCarById()
            {
                Id = id
            };

            Car car = await _mediator.Send(query);

            if (car == null)
            {
                Log.Instance.LogException("The Id could not be found");
                return NotFound();
            }

            GetCarViewModel getCarDto = _mapper.Map<GetCarViewModel>(car);
            return Ok(getCarDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCarModel addCarDto)
        {
            CreateCar command = _mapper.Map<CreateCar>(addCarDto);
            Car car = await _mediator.Send(command);
            GetCarViewModel getCarDto = _mapper.Map<GetCarViewModel>(car);

            Log.Instance.LogInformation($"{car.Make} {car.Model} was created  at {DateTime.Now.TimeOfDay}");

            return CreatedAtAction(nameof(GetById), new { Id = car.Id }, getCarDto);
        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> Edit([FromBody] EditCarViewModel editCarDto, int Id)
        {
            UpdateCar command = _mapper.Map<UpdateCar>(editCarDto);

            command.Id = Id;

            Log.Instance.LogInformation("Request with the updated car was sent!");

            Car car = await _mediator.Send(command);

            if (car == null)
            {
                return NotFound();
            }

            Log.Instance.LogInformation("The car was updated");

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            DeleteRating command = new DeleteRating()
            {
                Id = Id
            };

            try
            {
                Car car = await _mediator.Send(command);

                if (car == null)
                {
                    return NotFound();
                }

                Log.Instance.LogInformation($"Car with ID {Id} was deleted");

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{Id}/categories/{categoryId}")]
        public async Task<IActionResult> AddCategoryToCar(int Id, int categoryId)
        {
            var command = new AddCategoryToCar
            {
                CategoryId = categoryId,
                CarId = Id
            };

            var car = await _mediator.Send(command);

            if (car == null)
                return NotFound();

            Log.Instance.LogInformation("The car was updated");

            return Ok(_mapper.Map<GetCarViewModel>(car));
        }


    }
}
