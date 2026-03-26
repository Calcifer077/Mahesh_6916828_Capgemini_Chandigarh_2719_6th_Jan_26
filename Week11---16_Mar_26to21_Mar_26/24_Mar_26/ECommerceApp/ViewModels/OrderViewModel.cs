namespace ECommerceApp.ViewModels;

public class OrderViewModel
{
    public int OrderId { get; set; }
    public ShippingDetailViewModel? Shipping { get; set; }
    public List<OrderItemViewModel> Items { get; set; } = new();
    public decimal OrderTotal => Items.Sum(i => i.LineTotal);
}