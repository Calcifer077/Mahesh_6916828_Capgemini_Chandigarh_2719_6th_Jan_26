namespace ECommerceApp.ViewModels;

public class OrderItemViewModel
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal LineTotal => UnitPrice * Quantity;
}