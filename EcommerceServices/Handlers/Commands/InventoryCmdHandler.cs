using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Template.Repositories.Interfaces;
using static Template.Cqrs.Commands.InventoryCmd;

namespace Template.Handlers.Commands
{
    public class InventoryCmdHandler : IRequestHandler<UpdateInventory, string>
    {
        private readonly IInventoryUpdator inventoryUpdator;

        public InventoryCmdHandler(IInventoryUpdator inventoryUpdator)
        {
            this.inventoryUpdator = inventoryUpdator;
        }

        public async Task<string> Handle(UpdateInventory request, CancellationToken cancellationToken)
        {
            try
            {
                await inventoryUpdator.Update(request.productId, request.Quantity);

                return await Task.FromResult("Created");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
