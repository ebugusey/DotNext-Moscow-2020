using MediatR;

namespace HightechAngular.Shop.Features.Cart
{
    public class RemoveCartItem : IRequest<bool>
    {
        public int ProductId { get; }

        public RemoveCartItem(int productId)
        {
            ProductId = productId;
        }
    }
}
