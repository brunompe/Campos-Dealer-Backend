using System.ComponentModel.DataAnnotations;

namespace Campos_Dealer_Backend.Models.Product
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        public required string Description { get; set; }

        public required string Value { get; set; }
    }
}
