using Stock.Api.Services;

namespace Stock.Api.Endpoints
{
    public static class StockOutputEndPoint
    {
        public static void RegisterStockOutputEndPoint(this IEndpointRouteBuilder routes)
        {
            var stockOutput = routes.MapGroup("/stock-outputs");

            stockOutput.MapGet("", StockOutputService.GetAll).WithTags("Get all stock output");;
            stockOutput.MapGet("/{id}", StockOutputService.GetById).WithTags("Add stock output to list");;
            stockOutput.MapPost("", StockOutputService.Create).WithTags("Get stock output by Id");;
        }
    }
}
