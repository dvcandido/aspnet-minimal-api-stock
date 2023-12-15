using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
}