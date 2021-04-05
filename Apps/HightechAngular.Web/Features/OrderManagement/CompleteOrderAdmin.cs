using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using MediatR;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdmin: ChangeOrderStateBase, IRequest<HandlerResult<OrderStatus>>
    {
        public int   OrderId { get; set; }
    }
}
