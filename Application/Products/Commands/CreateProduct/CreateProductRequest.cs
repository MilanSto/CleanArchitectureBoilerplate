using System;

namespace Application.Products.Commands.CreateProduct;

public sealed record CreateProductRequest(string Name, DateTime Date, decimal Price, decimal Margin);