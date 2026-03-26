namespace ECommerceApp.ViewModels;

public class CustomerDashboardViewModel
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public List<OrderViewModel> Orders { get; set; } = new();

    // Useful computed properties for the dashboard
    public int TotalOrders => Orders.Count;
    public decimal TotalSpent => Orders.Sum(o => o.OrderTotal);
}