using Stock.Api.Services;

namespace Stock.Api.Endpoints
{
    public static class ProductsEndpoint
    {
        public static void RegisterProductsEndpoint(this IEndpointRouteBuilder routes)
        {
            var product = routes.MapGroup("/products");

            product.MapGet("", ProductService.GetAll).WithTags("Get all product");
            product.MapGet("/{id}", ProductService.GetById).WithTags("Get product by Id");
            product.MapPost("", ProductService.Create).WithTags("Add product to list");
            product.MapPut("/{id}", ProductService.Update).WithTags("Update product by Id");
            product.MapDelete("/{id}", ProductService.Delete).WithTags("Delete product by Id");
        }
    }
}