﻿using AspDotNetCrud.Data;
using AspDotNetCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCrud.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.Products.ToListAsync();

    public async Task<Product> GetByIdAsync(int id) =>
        await _context.Products.FindAsync(id);

    public async Task<Product> AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }
    
    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
    }
    
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}