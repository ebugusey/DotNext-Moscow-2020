using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using MediatR;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrder: ChangeOrderStateBase, IRequest<HandlerResult<OrderStatus>>
    {
        public int   OrderId { get; set; }
    }
}
