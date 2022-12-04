using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using RentACar.Api.Logger;
using RentACar.Core.Contracts;
using RentACar.Core.Models.Car;
using RentalCarManagementSystem.Core.Models.Car;
using System.Security.Claims;
using RentACar.Infrastructure.Entitites;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CarController : ControllerBase
    {
        private readonly ICarService carService;


        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(AllCarsViewModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> All()
        {
            var model = await carService.GetAllCarsAsync();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await carService.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }
       

        [HttpPost]
        [Route("Create")]

        public async Task<ActionResult<Car>> Add(CreateCarInputModel model)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest();
            }

            if ((await carService.IsDealer(userId)) == false)
            {
                return RedirectToAction(nameof(DealerController.Become), "Dealer");
            }

            if ((await carService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }


            await carService.CreateCar(model);

            return CreatedAtAction("GetCar", new { id = model.Id, model });
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(CarDetailsViewModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Details(int id)
        {
            var carModel = await carService.CarDetailsById(id);

            return Ok(carModel);
        }

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(CreateCarInputModel))]
        //[ProducesResponseType(500)]
        //public async Task<IActionResult> Add()
        //{
        //    var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        //    if (userId == null)
        //    {
        //        return BadRequest();
        //    }
        //    if ((await carService.IsDealer(userId)) == false)
        //    {
        //        return RedirectToAction(nameof(DealerController.Become), "Dealer");
        //    }

        //    var model = new CreateCarInputModel()
        //    {
        //        Categories = await carService.GetCategoriesAsync()
        //    };

        //    return Ok(model);
        //}
    }
}
