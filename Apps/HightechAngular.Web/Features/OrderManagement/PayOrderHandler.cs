using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Force.Ccc;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using MediatR;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class PayOrderHandler : IRequestHandler<PayOrder, HandlerResult<OrderStatus>>
    {
        private readonly IQueryable<Order> _orders;
        private readonly IUnitOfWork _unitOfWork;

        public PayOrderHandler(IQueryable<Order> orders, IUnitOfWork unitOfWork)
        {
            _orders = orders;
            _unitOfWork = unitOfWork;
        }

        public async Task<HandlerResult<OrderStatus>> Handle(PayOrder request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);
            var order = _orders.First(x => x.Id == request.OrderId);
            var result = order.BecomePaid();
            _unitOfWork.Commit();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
