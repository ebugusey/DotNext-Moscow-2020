using System.Linq;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs.Read;

namespace HightechAngular.Shop.Features.Index
{
    public class GetBestsellersQueryHandler : GetIntEnumerableQueryHandlerBase<GetBestsellers, Product, BestsellersListItem>
    {
        public GetBestsellersQueryHandler(IQueryable<Product> queryable) : base(queryable)
        {
        }
    }
}
