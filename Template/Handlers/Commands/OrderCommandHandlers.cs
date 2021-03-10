using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Template.Cqrs.Commands;
using Template.Dtos;
using Plain.RabbitMQ;

namespace Template.Handlers.Commands
{
    /// <summary>
    /// This class will handle the commands that are sent to the system
    /// </summary>
    public class OrderCommandHandlers : IRequestHandler<CreateOrder, string>,
                                        IRequestHandler<CancelOrder, string>
    {
        private readonly Plain.RabbitMQ.IPublisher publisher;

        public OrderCommandHandlers(Plain.RabbitMQ.IPublisher publisher)
        {
            this.publisher = publisher;
        }
        public Task<string> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            // Order insert report to database
            publisher.Publish(JsonConvert.SerializeObject(new OrderDetail()
            {
                Name = request.ProductName,
                Quantity = request.Quantity,
                User = request.Username
            }), "report.order", null);

            return Task.FromResult("Created");
        }

        public Task<string> Handle(CancelOrder request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
