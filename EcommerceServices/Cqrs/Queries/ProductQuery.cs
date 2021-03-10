using Template.Dtos;
using static Template.Cqrs.Queries.InventoryQuery;

namespace Template.Cqrs.Queries
{
    public class ProductQuery
    {
        /// <summary>
        /// List all orders for customer
        /// </summary>
        /// <remarks>
        /// Send this query command to get a list of all the orders in the system
        /// </remarks>
        public record GetProduct : IQuery<ProductDto[]>
        {
        }
    }
}
