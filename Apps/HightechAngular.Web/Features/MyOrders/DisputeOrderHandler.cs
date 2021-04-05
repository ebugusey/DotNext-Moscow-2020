using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using MediatR;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class DisputeOrderHandler : IRequestHandler<DisputeOrder, HandlerResult<OrderStatus>>
    {
        private readonly IQueryable<Order> _orders;

        public DisputeOrderHandler(IQueryable<Order> orders)
        {
            _orders = orders;
        }

        public async Task<HandlerResult<OrderStatus>> Handle(DisputeOrder request, CancellationToken cancellationToken)
        {
            var order = _orders.First(x => x.Id == request.OrderId);
            await Task.Delay(1000, cancellationToken);
            var result = order.BecomeDispute();

            return new HandlerResult<OrderStatus>(result);
        }
    }
}
