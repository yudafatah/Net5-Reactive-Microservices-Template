using System.ComponentModel.DataAnnotations;

namespace Template.Cqrs.Commands
{
    /// <summary>
    /// Add a new product to existing order
    /// </summary>
    /// <remarks>
    /// Send this command to add a new product to existing order. The order must still be open for this command to be accepted.
    /// </remarks>
    public record AddProduct : ICommand<string>
    {
        /// <summary>
        /// The Order ID
        /// </summary>
        /// <example>1234</example>
        [Required]
        public int OrderId { get; set; }

        /// <summary>
        /// The Product ID
        /// </summary>
        /// <example>1234</example>
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// The Quantity of products to add
        /// </summary> 
        /// <example>10</example>
        [Required]
        public int Quantity { get; set; }
    }

    /// <summary>
    /// Remove product from order
    /// </summary>
    /// <remarks>
    /// Removes the product from the provided order. The order must still be open for this command to be accepted.
    /// </remarks>
    public record RemoveProduct : ICommand<string>
    {
        /// <summary>
        /// The Order ID
        /// </summary>
        /// <example>1234</example>
        [Required]
        public int OrderId { get; set; }

        /// <summary>
        /// The Product ID
        /// </summary>
        /// <example>1234</example>
        [Required]
        public int ProductId { get; set; }
    }
}
