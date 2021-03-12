using Kafka.Public;
using Kafka.Public.Loggers;
using MasterRole_GetById.Tools;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Template.DTO;
using Template.Dtos;
using TemplateReport.Dtos;
using TemplateReport.Services;

namespace TemplateReport.Handlers
{
    public class ReportDataCollector : IHostedService
    {
        private const int DEFAULT_QUANTITY = 100;

        private readonly ISubscriber subscriber;
        private readonly IMemoryReportStorage memoryReportStorage;
        private readonly ILogger<ReportDataCollector> logger;
        private ClusterClient clusterClient;

        public ReportDataCollector(ISubscriber subscriber,
            IMemoryReportStorage memoryReportStorage,
            ILogger<ReportDataCollector> logger)
        {
            this.subscriber = subscriber;
            this.memoryReportStorage = memoryReportStorage;
            this.logger = logger;
            this.clusterClient = new ClusterClient(new Configuration
            {
                Seeds = GetConfig.AppSetting["KafkaHost"]
            }, new ConsoleLogger());
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // subscribe rabbit mq publisher
            subscriber.Subscribe(ProcessMessage);

            // consume message from kafka where the topic is EcommTopic
            clusterClient.ConsumeFromEarliest("EcommTopic");
            clusterClient.MessageReceived += record =>
            {
                var invent = JsonConvert.DeserializeObject<InventUpdateDto>
                (Encoding.UTF8.GetString(record.Value as byte[]));

                if (memoryReportStorage.GetInvent().Any(x => x.productId == invent.productId))
                {
                    // update invent report
                }
                else
                {
                    // product not found
                }
            };

            return Task.CompletedTask;
        }

        // process rabbit MQ message queue
        private bool ProcessMessage(string message, IDictionary<string, object> headers)
        {
            if (message.Contains("Product"))
            {
                var product = JsonConvert.DeserializeObject<ProductDto>(message);
                if (memoryReportStorage.Get().Any(x => x.ProductName.Equals(product.ProductName)))
                {
                    return true;
                }
                else
                {
                    memoryReportStorage.Add(new DTO.Report
                    {
                        ProductName = product.ProductName,
                        Count = DEFAULT_QUANTITY
                    });
                }
            }
            else
            {
                var order = JsonConvert.DeserializeObject<OrderDetail>(message);
                if (memoryReportStorage.Get().Any(x => x.ProductName.Equals(order.Name)))
                {
                    memoryReportStorage.Get().First(x => x.ProductName.Equals(order.Name)).Count -= order.Quantity;
                }
                else
                {
                    memoryReportStorage.Add(new DTO.Report
                    {
                        ProductName = order.Name,
                        Count = DEFAULT_QUANTITY - order.Quantity
                    });
                }
            }
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            clusterClient?.Dispose();
            return Task.CompletedTask;
        }
    }
}
