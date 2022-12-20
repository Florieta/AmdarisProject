using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Api.Logger;
using RentACar.Application.Orders.Commands.Create;
using RentACar.Application.Orders.Commands.Delete;
using RentACar.Application.Orders.Commands.Update;
using RentACar.Application.Orders.Queries;
using RentACar.Domain.Entitites;
using RentACar.WebApi.Middleware;
using RentACar.WebApi.ViewModels.Order;

namespace RentACar.WebApi.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public OrderController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> All()
        {
            Log.Instance.LogInformation("Retrieving the list of bookings");

            GetAllOrders query = new GetAllOrders();
            List<Order> result = await _mediator.Send(query);
            List<GetOrderViewModel> mappedResult = _mapper.Map<List<GetOrderViewModel>>(result);

            Log.Instance.LogInformation($"There are {result.Count} bookings in the fleet");

            return Ok(mappedResult);
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetById(int Id)
        {
            Log.Instance.LogInformation("Retrieving the booking by Id");

            GetOrderById query = new GetOrderById()
            {
                Id = Id
            };

            Order order = await _mediator.Send(query);

            if (order == null)
            {
                Log.Instance.LogWarning("The Id could not be found");
                return NotFound();
            }

            GetOrderViewModel getOrderDto = _mapper.Map<GetOrderViewModel>(order);
            return Ok(getOrderDto);
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] AddOrderModel addOrderDto)
        {

            CreateOrder command = _mapper.Map<CreateOrder>(addOrderDto);
            Order order = await _mediator.Send(command);
            GetOrderViewModel getOrderDto = _mapper.Map<GetOrderViewModel>(order);

            Log.Instance.LogInformation($"A new booking was created  at {DateTime.Now.TimeOfDay}");

            return CreatedAtAction(nameof(GetById), new { Id = order.Id }, getOrderDto);
        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> Edit([FromBody] EditOrderViewModel editOrderDto, int Id)
        {
            UpdateOrder command = _mapper.Map<UpdateOrder>(editOrderDto);

            command.Id = Id;

            Log.Instance.LogInformation("Request with the updated booking was sent!");

            Order order = await _mediator.Send(command);

            if (order == null)
            {
                return NotFound();
            }

            Log.Instance.LogInformation("The booking was updated");

            return NoContent();
        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> Delete(int Id)
        {
            DeleteOrder command = new() { Id = Id };

            try
            {
                Order order = await _mediator.Send(command);
                Log.Instance.LogInformation("A booking was deleted from the list");
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
