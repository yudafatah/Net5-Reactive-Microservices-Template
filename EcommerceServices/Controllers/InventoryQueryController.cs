using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Dtos;
using static Template.Cqrs.Queries.InventoryQuery;

namespace Template.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryQueryController : ControllerBase
    {
        private readonly IMediator mediator;

        public InventoryQueryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// Update inventory
        /// </summary>
        /// <remarks>
        /// Send this command to update inventory in the system
        /// </remarks>

        /// <param name="command">An instance of the CreateOrder
        /// <returns>The status of the operation</returns>
        /// <response code="200">Returns requested items</response>
        /// <response code="400">If the item is null</response> 
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(InventoryDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<InventoryDto[]> GetAll([FromBody] GetInventory command)
        {
            return await mediator.Send(command);
        }
    }
}
