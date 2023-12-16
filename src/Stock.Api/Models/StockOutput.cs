using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Stock.Api.Models
{
    //TODO : Add the necessary attributes to the StockOutput class to make it a valid model
    public class StockOutput
    {
        public int Id { get; set; }
        public int Quantity {get;set;}
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; } 
    }  
}