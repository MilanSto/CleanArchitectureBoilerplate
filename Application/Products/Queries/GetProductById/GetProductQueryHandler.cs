using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductById;

internal sealed class GetProductQueryHandler : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductQueryHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = _productRepository.GetById(request.ProductId);

        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        var response = new ProductResponse(product.Id, product.Name, product.Date, product.Price, product.MarginPercentage);

        return response;
    }
}