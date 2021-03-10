using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Template.Cqrs.Commands.InventoryCmd;

namespace Template.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryCmdController : ControllerBase
    {
        private readonly IMediator mediator;

        public InventoryCmdController(IMediator mediator)
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
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> Update([FromBody] UpdateInventory command)
        {
            return await mediator.Send(command);
        }
    }
}
