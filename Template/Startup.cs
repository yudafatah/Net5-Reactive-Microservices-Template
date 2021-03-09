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
using System.IO;
using System.Reflection;
using Template.Dtos;
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
                    Title = "Template Reactive Microservices with MediatR & CQRS", 
                    Version = "v1",
                    Description = "An example of using .NET 5 as reactive microservices",
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
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // register MediatR services
            services.AddMediatR(typeof(Startup));

            // register order detail repo and assign connection
            var connectionString = Configuration["ConnectionString"];
            services.AddSingleton<IOrderDetailsProvider>(new OrderDetailsProvider(connectionString));
            services.AddSingleton<IRepository<OrderDetail,OrderDto>>(new OrderDetailsProvider(connectionString));

            // register plain rabbit mq services
            services.AddSingleton<IConnectionProvider>(new ConnectionProvider("amqp://yudafatah:semen1976@localhost:5672"));
            services.AddScoped<Plain.RabbitMQ.IPublisher>(x => new Publisher(x.GetService<IConnectionProvider>(),
               "report_exchange",
               ExchangeType.Topic
               ));

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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SourceGenerator_MediatR_CQRS v1"));

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
