using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductById;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

/// <summary>
/// Represents the products controller.
/// </summary>
public sealed class ProductsController : ApiController
{
    /// <summary>
    /// Gets the product with the specified identifier, if it exists.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The product with the specified identifier, if it exists.</returns>
    [HttpGet("{productId:guid}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct(Guid productId, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(productId);

        var product = await Sender.Send(query, cancellationToken);

        return Ok(product);
    }

    /// <summary>
    /// Creates a new product based on the specified request.
    /// </summary>
    /// <param name="request">The create product request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The identifier of the newly created product.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct( [FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateProductCommand>();

        var productId = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetProduct), new { productId }, productId);
    }
}