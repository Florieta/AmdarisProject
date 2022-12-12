using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using RentACar.Api.Logger;
using System.Security.Claims;
using RentACar.Application.Cars.Queries;
using RentACar.Domain.Entitites;
using RentACar.WebApi.ViewModels.Car;
using RentACar.Application.Cars.Commands.Create;
using RentACar.Application.Cars.Commands.Update;
using RentACar.Application.Cars.Commands.Delete;

namespace RentACar.WebApi.Controllers
{
    [Route("api/Car")]
    [ApiController]

    public class CarController : BaseController<CarController>
    {
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            GetAllCars query = new GetAllCars();
            List<Car> result = await base.Mediator.Send(query);
            List<GetCarDto> mappedResult = base.Mapper.Map<List<GetCarDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("GetById/{carId}")]
        public async Task<IActionResult> GetById(int carId)
        {
            GetCarById query = new GetCarById()
            {
                Id = carId
            };

            Car car = await base.Mediator.Send(query);

            if (car == null)
            {
                return NotFound();
            }

            GetCarDto getCarDto = base.Mapper.Map<GetCarDto>(car);
            return Ok(getCarDto);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddCarDto addCarDto)
        {
            CreateCar command = base.Mapper.Map<CreateCar>(addCarDto);
            Car car = await base.Mediator.Send(command);
            GetCarDto getCarDto = base.Mapper.Map<GetCarDto>(car);
            return CreatedAtAction(nameof(GetById), new { carId = car.Id }, getCarDto);
        }

        [HttpPost]
        [Route("Edir/{carId}")]
        public async Task<IActionResult> Edit([FromBody] EditCarDto editCarDto, int carId)
        {
            UpdateCar command = base.Mapper.Map<UpdateCar>(editCarDto);

            command.Id = carId;

            Car car = await base.Mediator.Send(command);

            if (car == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("Delete/carId")]
        public async Task<IActionResult> Delete(int carId)
        {
            DeleteCar command = new DeleteCar()
            {
                Id = carId
            };

            try
            {
                Car car = await base.Mediator.Send(command);

                if (car == null)
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
