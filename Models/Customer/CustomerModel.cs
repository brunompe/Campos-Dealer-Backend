using System.ComponentModel.DataAnnotations;

namespace Campos_Dealer_Backend.Models.Customer
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string City { get; set; }
    }
}
