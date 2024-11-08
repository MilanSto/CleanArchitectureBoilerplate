using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Primitives;

namespace Domain.Entities;

public sealed class Product : Entity
{
    [SetsRequiredMembers]
    public Product(Guid id, string name, DateTime date, decimal price, decimal marginPercentage)
        : base(id)
    {
        Name = name;
        Date = date;
        Price = price;
        MarginPercentage = marginPercentage;
    }

    private Product()
    {
    }

    public string Name { get; private set; }

    public required DateTime Date { get; set; }
    public required decimal Price { get; set; }
    public decimal MarginPercentage { get; set; }
}