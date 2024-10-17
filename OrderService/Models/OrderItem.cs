namespace OrderService.Models
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> Products { get; set; } = new List<OrderItem>();
    }
}
