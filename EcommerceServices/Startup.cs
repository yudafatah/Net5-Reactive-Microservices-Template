using Confluent.Kafka;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Plain.RabbitMQ;
using RabbitMQ.Client;
using System;
using Template.Repositories.Implementation;
using Template.Repositories.Interfaces;

namespace Template
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Ecommerce Service", 
                    Version = "v1",
                    Description = "Template Reactive Microservices with MediatR & CQRS",
                    Contact = new OpenApiContact
                    {
                        Name = "Yuda Fatah",
                        Email = "yudafatah@gmail.com",
                        Url = new Uri("https://yudafatah.com/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });
                // Set the comments path for the Swagger JSON and UI if using Source Generator.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

            // register MediatR services
            services.AddMediatR(typeof(Startup));

            // register repo and assign connection
            var connectionString = Configuration["ConnectionString"];
            services.AddSingleton<IInventoryProvider>(new InventoryProvider(connectionString));
            services.AddSingleton<IProductProvider>(new ProductProvider(connectionString));
            services.AddSingleton<IInventoryUpdator>(new InventoryUpdator(connectionString));

            // register plain rabbit mq services
            services.AddSingleton<IConnectionProvider>(new ConnectionProvider("amqp://yudafatah:semen1976@localhost:5672"));
            services.AddScoped<Plain.RabbitMQ.IPublisher>(x => new Publisher(x.GetService<IConnectionProvider>(),
               "report_exchange",
               ExchangeType.Topic
               ));

            // register kafka producer
            var producerConf = new ProducerConfig();
            Configuration.Bind("Producer", producerConf);
            services.AddSingleton<ProducerConfig>(producerConf);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
