using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Stock.Api.Models
{
    public class StockOutput
    {
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public int Quantity {get;set;}
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; } 
    }  
}