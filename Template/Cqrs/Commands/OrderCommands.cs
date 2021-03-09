using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Cqrs.Commands
{
    /// <summary>
    /// Interface that represents a command to the system
    /// </summary>
    public interface ICommand<T> : IRequest<T>
    {
    }

    /// <summary>
    /// Create a new order
    /// </summary>
    /// <remarks>
    /// Send this command to create a new order in the system for a given customer
    /// </remarks>
    public record CreateOrder : ICommand<string>
    {
        /// <summary>
        /// The User Id
        /// </summary>
        /// <example>1234</example>
        public int UserId { get; set; }
        /// <summary>
        /// The UpdatedTime
        /// </summary>
        /// <example>null if not update action</example>
        public DateTime UpdatedTime { get; set; }
        /// <summary>
        /// The Username
        /// </summary>
        /// <example>yuda fatah</example>
        public string Username { get; set; }
        /// <summary>
        /// The Product Id
        /// </summary>
        /// <example>123</example>
        public int ProductId { get; set; }
        /// <summary>
        /// The Product Quantity
        /// </summary>
        /// <example>123</example>
        public int Quantity { get; set; }
        /// <summary>
        /// The Product Name
        /// </summary>
        /// <example>Lambo</example>
        public string ProductName { get; set; }
    }

    /// <summary>
    /// Cancels an order
    /// </summary>
    /// <remarks>
    /// This command will cancel the order. The order must still be open for this command to be accepted.
    /// </remarks>
    public record CancelOrder : ICommand<string>
    {
        /// <summary>
        /// The Order ID
        /// </summary>
        /// <example>1234</example>
        [Required]
        public int OrderId { get; set; }

        /// <summary>
        /// The reason for why this order is cancelled
        /// </summary>
        /// <example>1234</example>
        [Required]
        public string Reason { get; set; }

        /// <summary>
        /// Who cancelled this order?
        /// </summary>
        /// <example>Tore Nestenius</example>
        [Required]
        public string CancelledBy { get; set; }
    }
}
