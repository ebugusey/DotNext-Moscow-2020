using System;
using System.Threading.Tasks;
using Force.Cqrs;
using Force.Ddd;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using MediatR;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class PayOrder : HasIdBase, ICommand<Task<HandlerResult<OrderStatus>>>, IRequest<HandlerResult<OrderStatus>>
    {
        public int OrderId { get; set; }
    }
}
