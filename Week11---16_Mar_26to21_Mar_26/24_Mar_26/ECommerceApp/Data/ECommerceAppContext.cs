using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Models;
using ECommerceApp.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ECommerceApp.Data
{
    public class ECommerceAppContext : IdentityDbContext
    {
        public ECommerceAppContext (DbContextOptions<ECommerceAppContext> options)
            : base(options)
        {
        }

        public DbSet<ECommerceApp.Models.Category> Category { get; set; } = default!;
        public DbSet<ECommerceApp.Models.Customer> Customer { get; set; } = default!;
        public DbSet<ECommerceApp.Models.Order> Order { get; set; } = default!;
        public DbSet<ECommerceApp.Models.OrderItem> OrderItem { get; set; } = default!;
        public DbSet<ECommerceApp.Models.Product> Product { get; set; } = default!;
        public DbSet<ECommerceApp.Models.ShippingDetail> ShippingDetail { get; set; } = default!;
    }
}
