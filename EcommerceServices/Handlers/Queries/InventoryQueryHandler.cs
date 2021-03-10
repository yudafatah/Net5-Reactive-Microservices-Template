using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Template.Dtos;
using Template.Repositories.Interfaces;
using static Template.Cqrs.Queries.InventoryQuery;

namespace Template.Handlers.Queries
{
    public class InventoryQueryHandler : IRequestHandler<GetInventory, InventoryDto[]>
    {
        private readonly IInventoryProvider inventoryProvider;

        public InventoryQueryHandler(IInventoryProvider inventoryProvider)
        {
            this.inventoryProvider = inventoryProvider;
        }
        public Task<InventoryDto[]> Handle(GetInventory request, CancellationToken cancellationToken)
        {
            return Task.FromResult(inventoryProvider.Get());
        }
    }
}
