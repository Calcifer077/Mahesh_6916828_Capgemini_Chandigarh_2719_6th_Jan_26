namespace ECommerceApp.Models;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public ShippingDetail? ShippingDetail { get; set; }
}