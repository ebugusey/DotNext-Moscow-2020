using System.Linq;
using HightechAngular.Orders.Entities;
using HightechAngular.Orders.Services;
using MediatR;

namespace HightechAngular.Shop.Features.Cart
{
    public class UpdateCartHandler : RequestHandler<UpdateCart, int>
    {
        private readonly ICartStorage _cartStorage;
        private readonly IQueryable<Product> _products;

        public UpdateCartHandler(ICartStorage cartStorage, IQueryable<Product> products)
        {
            _cartStorage = cartStorage;
            _products = products;
        }

        protected override int Handle(UpdateCart request)
        {
            var product = _products.First(x => x.Id == request.ProductId);
            _cartStorage.Cart.AddProduct(product);
            _cartStorage.SaveChanges();

            return product.Id;
        }
    }
}
