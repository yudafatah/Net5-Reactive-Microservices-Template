using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Cqrs.Queries;
using Template.Dtos;

namespace Template.Controllers
{
    /// <summary>
    /// This is the controller class for order queries in the system
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderQueryController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrderQueryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IEnumerable<OrderDetail>> GetAll([FromBody] ListAllOrders command)
        {
            return await mediator.Send(command);
        }
    }
}
