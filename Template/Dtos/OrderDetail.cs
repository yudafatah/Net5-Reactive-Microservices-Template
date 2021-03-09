using System;

namespace Template.Dtos
{
    public class OrderDetail
    {
        public string User { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderDto
    {
        public int UserId { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string Username { get; set; }
        public int ProductId { get; set; }
        public int Quantity{ get; set; }
        public string ProductName { get; set; }
    }
}
