using FluentValidation;

namespace Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Date).NotEmpty();

        RuleFor(x => x.Price).NotEmpty();
    }
}