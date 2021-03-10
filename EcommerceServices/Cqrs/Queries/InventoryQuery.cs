using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Dtos;

namespace Template.Cqrs.Queries
{
    public class InventoryQuery
    {
        /// <summary>
        /// Interface that represents a query to the system
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IQuery<T> : IRequest<T>
        {
        }


        /// <summary>
        /// List all orders for customer
        /// </summary>
        /// <remarks>
        /// Send this query command to get a list of all the orders in the system
        /// </remarks>
        public record GetInventory : IQuery<InventoryDto[]>
        {
        }
    }
}
