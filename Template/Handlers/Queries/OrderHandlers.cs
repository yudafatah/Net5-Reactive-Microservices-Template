using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Template.Cqrs.Queries;
using Template.Dtos;
using Template.Repositories.Interfaces;

namespace Template.Handlers.Queries
{
    public class OrderHandlers : IRequestHandler<ListAllOrders, IEnumerable<OrderDetail>>,
                                IRequestHandler<ListAllOrdersForCustomer, List<OrderDetail>>,
                                IRequestHandler<ListTodaysOrders, List<OrderDetail>>,
                                IRequestHandler<GetOrder, OrderDetail>
    {
        private readonly IRepository<OrderDetail, OrderDto> repository;
        public OrderHandlers(IRepository<OrderDetail, OrderDto> repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<OrderDetail>> Handle(ListAllOrders request, CancellationToken cancellationToken)
        {
            return await repository.GetAll();
        }

        public Task<List<OrderDetail>> Handle(ListAllOrdersForCustomer request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDetail>> Handle(ListTodaysOrders request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> Handle(GetOrder request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
