using Microsoft.AspNetCore.Mvc;
using ProductManagement.Filters;
using ProductManagement.Models;
using System;
using System.Collections.Generic;

namespace ProductApp.Controllers
{
    [ServiceFilter(typeof(LogActionFilter))]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // Simulate an exception for testing
            //throw new Exception("Test Exception from Index action");

            var products = new List<Product>
            {
                new Product{ Id=1, Name="Laptop", Price=900 },
                new Product{ Id=2, Name="Phone", Price=500 }
            };

            return View(products);
        }
    }
}