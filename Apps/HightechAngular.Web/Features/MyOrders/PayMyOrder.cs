using System.Threading.Tasks;
using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using MediatR;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class PayMyOrder: ICommand<Task<HandlerResult<OrderStatus>>>, IRequest<HandlerResult<OrderStatus>>
    {
        public int   OrderId { get; set; }
    }
}
