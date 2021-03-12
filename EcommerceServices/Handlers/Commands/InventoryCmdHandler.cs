using Confluent.Kafka;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Template.Dtos;
using Template.Repositories.Interfaces;
using static Template.Cqrs.Commands.InventoryCmd;

namespace Template.Handlers.Commands
{
    public class InventoryCmdHandler : IRequestHandler<UpdateInventory, string>
    {
        private readonly IInventoryUpdator inventoryUpdator;
        private readonly ProducerConfig producerConfig;

        public InventoryCmdHandler(IInventoryUpdator inventoryUpdator,
            ProducerConfig producerConfig)
        {
            this.inventoryUpdator = inventoryUpdator;
            this.producerConfig = producerConfig;
        }

        public async Task<string> Handle(UpdateInventory request, CancellationToken cancellationToken)
        {
            try
            {
                await inventoryUpdator.Update(request.productId, request.Quantity);

                // send report to consumer with kafka producer
                string serializedInventory = JsonConvert.SerializeObject(new InventUpdateDto()
                {
                    productId = request.productId,
                    Quantity = request.Quantity
                });
                using(var producer = new ProducerBuilder<Null, string>(producerConfig).Build())
                {
                    await producer.ProduceAsync("EcommTopic", new Message<Null, string> { Value = serializedInventory });
                    producer.Flush(TimeSpan.FromSeconds(10));
                }

                return await Task.FromResult("Created");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
