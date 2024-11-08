using Domain.Abstractions;
using Domain.Entities;
using System;

namespace Infrastructure.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public Product GetById(Guid id) => _dbContext.Find<Product>(id);

    public void Insert(Product product) => _dbContext.Set<Product>().Add(product);
}