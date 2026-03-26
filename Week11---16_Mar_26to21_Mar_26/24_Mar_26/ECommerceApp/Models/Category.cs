using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}