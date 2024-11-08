using System;

namespace Application.Products.Queries.GetProductById;

public sealed record ProductResponse(Guid Id, string Name, DateTime Date, decimal Price, decimal Margin);