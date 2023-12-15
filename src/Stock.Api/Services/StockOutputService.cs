using System.Data;
using Microsoft.EntityFrameworkCore;
using Stock.Api.Models;

namespace Stock.Api.Services
{
    public static class StockOutputService
    {
        public static async Task<List<StockOutput>> GetAll(StockContext context) =>
                        await context.StockOutput.Include(x => x.Product).ToListAsync();

        public static async Task<IResult> GetById(int id, StockContext context) =>
            await context.StockOutput.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id)
                    is StockOutput stockOutput
                        ? Results.Ok(stockOutput)
                        : Results.NotFound();

        public static async Task<IResult> Create(StockOutput stockOutput, StockContext context)
        {
            var product = await context.Product.FindAsync(stockOutput.ProductId);

            if (product is null) return Results.NotFound();

            if (product.Quantity == 0)
                return Results.BadRequest("Product out of stock");

            if (stockOutput.Quantity > product.Quantity)
                return Results.BadRequest("Insufficient product quantity");

            using var transaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead);

            try
            {
                context.StockOutput.Add(stockOutput);
                product.DecreaseStock(stockOutput.Quantity);
                context.Product.Update(product);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Results.Created($"/stock-outputs/{stockOutput.Id}", stockOutput);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return Results.BadRequest();
            }
        }

    }
}