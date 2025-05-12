using AspDotNetCrud.DTOs;
using AspDotNetCrud.Models;
using AspDotNetCrud.Repositories;

namespace AspDotNetCrud.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    
    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public Task<IEnumerable<Product>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Product> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public async Task<Product> CreateAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price
        };
        _repository.Add(product);
        await _repository.SaveAsync();
        return product;
    }

    public async Task<bool> UpdateAsync(int id, ProductDto productDto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        existing.Name = productDto.Name;
        existing.Price = productDto.Price;
        await _repository.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        await _repository.DeleteAsync(existing);
        return true;
    }
}