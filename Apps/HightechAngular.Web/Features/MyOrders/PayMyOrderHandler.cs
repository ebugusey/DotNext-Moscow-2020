using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Force.Ccc;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using MediatR;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class PayMyOrderHandler : IRequestHandler<PayMyOrder, HandlerResult<OrderStatus>>
    {
        private readonly IQueryable<Order> _orders;
        private readonly IUnitOfWork _unitOfWork;

        public PayMyOrderHandler(IQueryable<Order> orders, IUnitOfWork unitOfWork)
        {
            _orders = orders;
            _unitOfWork = unitOfWork;
        }

        public async Task<HandlerResult<OrderStatus>> Handle(PayMyOrder request, CancellationToken cancellationToken)
        {
            var order = _orders.First(x => x.Id == request.OrderId);
            await Task.Delay(1000, cancellationToken);
            var result = order.BecomePaid();
            _unitOfWork.Commit();

            return new HandlerResult<OrderStatus>(result);
        }
    }
}
