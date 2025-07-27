using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UseOfMastransistForRabbitMQ.Models;
using MassTransit

namespace UseOfMastransistForRabbitMQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IPublishEndpoint publishEndpoint) : ControllerBase
    {
        // In-memory product list for demonstration
        private static readonly List<Product> Products = new();
        
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(Guid id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {

            Products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            Products.Remove(product);
            return NoContent();
        }
    }

}