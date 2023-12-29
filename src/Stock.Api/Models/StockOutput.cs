using FluentValidation;

namespace Stock.Api.Models
{
    public class StockOutput
    {
        public int Id { get; set; }
        public int Quantity {get;set;}
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; } 
    }  

    public class StockOutputValidator : AbstractValidator<StockOutput>
    {
        public StockOutputValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required");
        }
    }
}