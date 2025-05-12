using AspDotNetCrud.Data;
using AspDotNetCrud.DTOs;
using AspDotNetCrud.Models;
using AspDotNetCrud.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    
    private readonly IProductService _service;
    
    public ProductsController(AppDbContext context, IProductService service)
    {
        _context = context;
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get() =>
        Ok(await _service.GetAllAsync());
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(int id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }
    
    [HttpPost]
    public async Task<ActionResult<Product>> Post(ProductDto productDto)
    {
        var created = await _service.CreateAsync(productDto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ProductDto productDto)
    {
        var updated = await _service.UpdateAsync(id, productDto);
        if (!updated) return NotFound();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
