using HightechAngular.Orders.Services;
using MediatR;

namespace HightechAngular.Shop.Features.Cart
{
    public class RemoveCartItemHandler : RequestHandler<RemoveCartItem, bool>
    {
        private readonly ICartStorage _cartStorage;

        public RemoveCartItemHandler(ICartStorage cartStorage)
        {
            _cartStorage = cartStorage;
        }

        protected override bool Handle(RemoveCartItem request)
        {
            var res = _cartStorage.Cart.TryRemoveProduct(request.ProductId);
            _cartStorage.SaveChanges();

            return res;
        }
    }
}
