using Force.Ccc;
using HightechAngular.Orders.Entities;
using HightechAngular.Orders.Services;
using MediatR;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CreateOrderHandler : RequestHandler<CreateOrder, int>
    {
        private readonly ICartStorage _cartStorage;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderHandler(ICartStorage cartStorage, IUnitOfWork unitOfWork)
        {
            _cartStorage = cartStorage;
            _unitOfWork = unitOfWork;
        }

        protected override int Handle(CreateOrder request)
        {
            var order = new Order(_cartStorage.Cart);

            _unitOfWork.Add(order);
            _cartStorage.EmptyCart();
            _unitOfWork.Commit();

            return order.Id;
        }
    }
}
