using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Stock.Api.Models
{
    //TODO 1: Add the necessary attributes to the Product class to make it a valid model
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
}