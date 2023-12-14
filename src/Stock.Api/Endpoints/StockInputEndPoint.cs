using Stock.Api.Services;

namespace Stock.Api.Endpoints
{
    public static class StockInputEndPoint
    {
        public static void RegisterStockInputEndPoint(this IEndpointRouteBuilder routes)
        {
            var stockInput = routes.MapGroup("/stock-inputs");

            stockInput.MapGet("", StockInputService.GetAll).WithTags("Get all stock input");
            stockInput.MapGet("/{id}", StockInputService.GetById).WithTags("Add stock input to list");
            stockInput.MapPost("", StockInputService.Create).WithTags("Get stock input by Id");
        }
    }
}
