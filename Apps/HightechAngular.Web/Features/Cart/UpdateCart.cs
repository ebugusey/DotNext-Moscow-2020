using MediatR;

namespace HightechAngular.Shop.Features.Cart
{
    public class UpdateCart : IRequest<int>
    {
        public int ProductId { get; }

        public UpdateCart(int productId)
        {
            ProductId = productId;
        }
    }
}
