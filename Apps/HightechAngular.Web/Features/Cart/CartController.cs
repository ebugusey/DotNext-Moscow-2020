using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Force.Extensions;
using HightechAngular.Orders.Entities;
using HightechAngular.Orders.Services;
using Infrastructure.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Shop.Features.Cart
{
    public class CartController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<List<CartItem>> Get([FromServices] ICartStorage storage) =>
            storage.Cart.CartItems.PipeTo(Ok);

        [HttpPut("Add")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Add([FromBody] int productId)
        {
            var command = new UpdateCart(productId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Remove")]
        public async Task<ActionResult<bool>> Remove([FromBody] int productId)
        {
            var command = new RemoveCartItem(productId);
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
