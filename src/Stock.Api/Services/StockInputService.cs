using System.Data;
using Microsoft.EntityFrameworkCore;
using Stock.Api.Models;

namespace Stock.Api.Services
{
    public static class StockInputService
    {
        public static async Task<List<StockInput>> GetAll(StockContext context) =>
                        await context.StockInput.Include(x => x.Product).ToListAsync();

        public static async Task<IResult> GetById(int id, StockContext context) =>
            await context.StockInput.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id) 
                is StockInput stockInput
                    ? Results.Ok(stockInput)
                    : Results.NotFound();

        public static async Task<IResult> Create(StockInput stockInput, StockContext context)
        {
            var product = await context.Product.FindAsync(stockInput.ProductId);

            if (product is null) return Results.NotFound();

            using var transaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead);

            try
            {
                context.StockInput.Add(stockInput);
                product.IncreaseStock(stockInput.Quantity);
                context.Product.Update(product);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Results.Created($"/stock-inputs/{stockInput.Id}", stockInput);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return Results.BadRequest();
            }
        }
    }
}