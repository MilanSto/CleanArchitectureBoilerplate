using System;
using Application.Abstractions.Messaging;

namespace Application.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, DateTime Date, decimal Price, decimal Margin) : ICommand<Guid>
{

}
