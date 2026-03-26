using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}