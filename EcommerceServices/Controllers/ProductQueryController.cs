using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Dtos;
using static Template.Cqrs.Queries.ProductQuery;

namespace Template.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductQueryController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductQueryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// Get All Products
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
        [ProducesResponseType(typeof(ProductDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ProductDto[]> GetAll([FromBody] GetProduct command)
        {
            return await mediator.Send(command);
        }
    }
}
