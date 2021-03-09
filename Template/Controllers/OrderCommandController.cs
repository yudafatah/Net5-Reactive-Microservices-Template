using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Cqrs.Commands;

namespace Template.Controllers
{
    /// <summary>
    /// This is the controller class for order commands in the system
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderCommandController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderCommandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <remarks>
        /// Send this command to create a new order in the system for a given customer
        /// </remarks>

        /// <param name="command">An instance of the CreateOrder
        /// <returns>The status of the operation</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> Create([FromBody] CreateOrder command)
        {
            return await mediator.Send(command);
        }
    }
}
