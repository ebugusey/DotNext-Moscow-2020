using System.Linq;
using HightechAngular.Orders.Entities;
using Infrastructure.Ddd;

namespace HightechAngular.Shop.Features.Index
{
    public class GetBestsellersFilter : IFilter<Product, GetBestsellers>
    {
        public IQueryable<Product> Filter(IQueryable<Product> queryable, GetBestsellers predicate)
        {
            return queryable.Where(Product.Specs.IsBestseller);
        }
    }
}
