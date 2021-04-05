using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using MediatR;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CompleteOrder : ChangeOrderStateBase, IRequest<HandlerResult<OrderStatus>>
    {
        public int   OrderId { get; set; }
    }
}
