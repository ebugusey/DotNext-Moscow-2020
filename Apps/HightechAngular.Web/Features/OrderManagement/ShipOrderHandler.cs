using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using MediatR;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrderHandler : IRequestHandler<ShipOrder, HandlerResult<OrderStatus>>
    {
        private readonly IQueryable<Order> _orders;

        public ShipOrderHandler(IQueryable<Order> orders)
        {
            _orders = orders;
        }

        public async Task<HandlerResult<OrderStatus>> Handle(ShipOrder request, CancellationToken cancellationToken)
        {
            var order = _orders.First(x => x.Id == request.OrderId);
            await Task.Delay(1000, cancellationToken);
            var result = order.BecomeShipped();

            return new HandlerResult<OrderStatus>(result);
        }
    }
}
