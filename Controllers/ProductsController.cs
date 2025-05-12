﻿using AspDotNetCrud.Data;
using AspDotNetCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() =>
            _context.Products.ToList();
    
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return product;
        }
    
        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            var existing = _context.Products.Find(id);
            if (existing == null) return NotFound();

            existing.Name = product.Name;
            existing.Price = product.Price;
            _context.SaveChanges();
            return NoContent();
        }
    
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

