using Force.Cqrs;
using MediatR;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CreateOrder : ICommand<int>, IRequest<int>
    {
    }
}
