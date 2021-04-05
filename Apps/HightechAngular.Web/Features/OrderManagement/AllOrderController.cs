using System.Linq;
using System.Threading.Tasks;
using Force.Extensions;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;
using Infrastructure.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class OrderController : ApiControllerBase
    {
        private readonly IQueryable<Order> _orders;
        private readonly IMediator _mediator;

        public OrderController(IQueryable<Order> orders, IMediator mediator)
        {
            _orders = orders;
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(OrderListItem), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] GetAllOrders query) =>
            _orders
                .Select(AllOrdersItem.Map)
                .PipeTo(Ok);

        [HttpPut("PayOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PayOrder([FromBody] PayOrder command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetOrders")]
        [ProducesResponseType(typeof(AllOrdersItem), StatusCodes.Status200OK)]
        public IActionResult GetOrders([FromQuery] GetMyOrders query) =>
            _orders
                .Select(AllOrdersItem.Map)
                .PipeTo(Ok);

        [HttpPut("Shipped")]
        public async Task<IActionResult> Shipped([FromBody] ShipOrder command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete([FromBody] CompleteOrderAdmin command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
