using System.Text.Json.Serialization;
using FluentValidation;

namespace Stock.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; private set; }

        [JsonIgnore]
        public ICollection<StockInput>? StockInputs { get; set; }

        [JsonIgnore]
        public ICollection<StockOutput>? StockOutputs { get; set; }

        public void IncreaseStock(int quantity) => Quantity += quantity;

        public void DecreaseStock(int quantity) => Quantity -= quantity;
    }

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to 0");
        }
    }
}