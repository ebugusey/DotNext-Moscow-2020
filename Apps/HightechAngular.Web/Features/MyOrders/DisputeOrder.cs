using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using MediatR;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class DisputeOrder : ChangeOrderStateBase, IRequest<HandlerResult<OrderStatus>>
    {
        public int   OrderId { get; set; }
    }
}
