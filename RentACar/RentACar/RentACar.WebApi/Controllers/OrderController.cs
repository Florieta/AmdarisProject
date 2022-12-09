using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Orders.Commands.Create;
using RentACar.Application.Orders.Commands.Update;
using RentACar.Application.Orders.Queries;
using RentACar.Domain.Entitites;
using RentACar.WebApi.Dtos.Order;

namespace RentACar.WebApi.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : BaseController<OrderController>
    {
        [HttpGet]
        [Route("/All")]
        public async Task<IActionResult> All()
        {
            GetAllOrders query = new GetAllOrders();
            List<Order> result = await base.Madiator.Send(query);
            List<GetOrderDto> mappedResult = base.Mapper.Map<List<GetOrderDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("/GetById/{carId}")]
        public async Task<IActionResult> GetById(int carId)
        {
            GetOrderById query = new GetOrderById()
            {
                Id = carId
            };

            Order order = await base.Madiator.Send(query);

            if (order == null)
            {
                return NotFound();
            }

            GetOrderDto getOrderDto = base.Mapper.Map<GetOrderDto>(order);
            return Ok(getOrderDto);
        }

        [HttpPost]
        [Route("/Add")]
        public async Task<IActionResult> Add([FromBody] AddOrderDto addOrderDto)
        {
           
            CreateOrder command = base.Mapper.Map<CreateOrder>(addOrderDto);
            Order order = await base.Madiator.Send(command);
            GetOrderDto getCarDto = base.Mapper.Map<GetOrderDto>(order);
            return CreatedAtAction(nameof(GetById), new { orderId = order.Id }, getCarDto);
        }

        [HttpPost]
        [Route("/Edir/{orderId}")]
        public async Task<IActionResult> Edit([FromBody] EditOrderDto editOrderDto, int orderId)
        {
            UpdateOrder command = base.Mapper.Map<UpdateOrder>(editOrderDto);

            command.Id = orderId;

            Order order = await base.Madiator.Send(command);

            if (order == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
