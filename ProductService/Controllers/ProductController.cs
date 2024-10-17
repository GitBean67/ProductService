using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using System.Collections.Generic;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Price = 999.99M },
            new Product { ProductId = 2, ProductName = "Smartphone", Price = 499.99M }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => Ok(products);

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.Find(p => p.ProductId == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.ProductId = products.Count + 1;
            products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }
    }
}
