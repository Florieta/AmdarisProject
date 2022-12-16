using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Orders.Commands.Create;
using RentACar.Application.Orders.Commands.Delete;
using RentACar.Application.Orders.Commands.Update;
using RentACar.Application.Orders.Queries;
using RentACar.Domain.Entitites;
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
            GetAllOrders query = new GetAllOrders();
            List<Order> result = await _mediator.Send(query);
            List<GetOrderViewModel> mappedResult = _mapper.Map<List<GetOrderViewModel>>(result);
            return Ok(mappedResult);
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetById(int orderId)
        {
            GetOrderById query = new GetOrderById()
            {
                Id = orderId
            };

            Order order = await _mediator.Send(query);

            if (order == null)
            {
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
            return CreatedAtAction(nameof(GetById), new { orderId = order.Id }, getOrderDto);
        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> Edit([FromBody] EditOrderViewModel editOrderDto, int orderId)
        {
            UpdateOrder command = _mapper.Map<UpdateOrder>(editOrderDto);

            command.Id = orderId;

            Order order = await _mediator.Send(command);

            if (order == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> Delete(int orderId)
        {
            DeleteOrder command = new() { Id = orderId };

            try
            {
                Order order = await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
