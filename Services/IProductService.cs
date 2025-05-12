using AspDotNetCrud.DTOs;
using AspDotNetCrud.Models;

namespace AspDotNetCrud.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> CreateAsync(ProductDto productDto);
    Task<bool> UpdateAsync(int id, ProductDto productDto);
    Task<bool> DeleteAsync(int id);
}