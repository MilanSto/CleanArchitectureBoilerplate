using System;
using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid productId)
        : base($"Product with the identifier {productId} was not found.")
    {
    }
}