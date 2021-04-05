using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HightechAngular.Identity.Services;
using HightechAngular.Orders.Entities;
using Infrastructure.AspNetCore;
using Infrastructure.Cqrs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class MyOrdersController : ApiControllerBase
    {
        private readonly IQueryable<Order> _orders;
        private readonly IUserContext _userContext;
        private readonly IMediator _mediator;

        public MyOrdersController(IQueryable<Order> orders,
            IUserContext userContext, IMediator mediator)
        {
            _orders = orders;
            _userContext = userContext;
            _mediator = mediator;
        }

        [HttpPost("CreateNew")]
        [Authorize]
        public async Task<ActionResult<int>> CreateNew([FromBody] CreateOrder command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("GetMyOrders")]
        public ActionResult<IEnumerable<OrderListItem>> GetMyOrders([FromQuery] GetMyOrders query)
        {
            var orders = _orders
                .Where(Order.Specs.ByUserName(_userContext.User?.UserName))
                .Select(OrderListItem.Map);
            return Ok(orders);
        }

        [HttpPut("Dispute")]
        public async Task<IActionResult> Dispute([FromBody] DisputeOrder command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete([FromBody] CompleteOrder command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("PayOrder")]
        public async Task<IActionResult> PayOrder([FromBody] PayMyOrder command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
