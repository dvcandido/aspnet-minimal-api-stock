using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Stock.Api.Models;

namespace Stock.Api.Services
{
    public static class ProductService
    {
        public static async Task<List<Product>> GetAll(StockContext context) =>
                        await context.Product.ToListAsync();

        public static async Task<IResult> GetById(int id, StockContext context) =>
            await context.Product.FindAsync(id)
                    is Product product
                        ? Results.Ok(product)
                        : Results.NotFound();

        public static async Task<IResult> Create(Product product, StockContext context, IValidator<Product> validator)
        {
            var validationResult = await validator.ValidateAsync(product);

            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors);

            context.Product.Add(product);
            await context.SaveChangesAsync();

            return Results.Created($"/products/{product.Id}", product);
        }

        public static async Task<IResult> Update(int id, Product inputProduct, StockContext context, IValidator<Product> validator)
        {
            var validationResult = await validator.ValidateAsync(inputProduct);

            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.Errors);

            var product = await context.Product.FindAsync(id);

            if (product is null) return Results.NotFound();

            product.Name = inputProduct.Name;
            product.Price = inputProduct.Price;

            await context.SaveChangesAsync();

            return Results.NoContent();
        }

        public static async Task<IResult> Delete(int id, StockContext context)
        {
            var product = await context.Product.FindAsync(id);

            if (product is null) return Results.NotFound();

            context.Product.Remove(product);
            await context.SaveChangesAsync();
            return Results.NoContent();
        }
    }
}