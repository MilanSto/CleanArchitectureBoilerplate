using Domain.Entities;
using System;

namespace Domain.Abstractions;

public interface IProductRepository
{
    void Insert(Product product);

    Product GetById(Guid id);
}