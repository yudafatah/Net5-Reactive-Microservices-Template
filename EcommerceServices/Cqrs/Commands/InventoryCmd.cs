using MediatR;
using System;

namespace Template.Cqrs.Commands
{
    public class InventoryCmd
    {
        /// <summary>
        /// Interface that represents a command to the system
        /// </summary>
        public interface ICommand<T> : IRequest<T>
        {
        }

        /// <summary>
        /// Update Inventory
        /// </summary>
        /// <remarks>
        /// Send this command to Update Inventory in the system
        /// </remarks>
        public record UpdateInventory : ICommand<string>
        {
            /// <summary>
            /// The product Id
            /// </summary>
            /// <example>1234</example>
            public int productId { get; set; }
            /// <summary>
            /// The Product Quantity
            /// </summary>
            /// <example>123</example>
            public int Quantity { get; set; }
        }
    }
}
