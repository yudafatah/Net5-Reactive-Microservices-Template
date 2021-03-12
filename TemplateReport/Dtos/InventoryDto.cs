namespace Template.Dtos
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }

    public class InventUpdateDto
    {
        public int productId { get; set; }
        public int Quantity { get; set; }
    }
}
