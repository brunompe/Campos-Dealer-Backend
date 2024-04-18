using System.ComponentModel.DataAnnotations;

namespace Campos_Dealer_Backend.Models.Sales
{
    public class SaleModel
    {

        [Key]
        public int Id { get; set; }

        public required int CustomerId { get; set; }

        public required int ProductId { get; set; }

        public required int Quantity { get; set; }

        public required int ProductPrice { get; set; }

        public  DateTime SaleDate { get; set; } = DateTime.Now;

        public float TotalPrice { get; private set; }
        public SaleModel()
        {
            CalculateTotalPrice();
        }

        public void CalculateTotalPrice()
        {
            TotalPrice = Quantity * ProductPrice;
        }

        public void UpdateSale(int quantity, int productPrice)
        {
            Quantity = quantity;
            ProductPrice = productPrice;
            CalculateTotalPrice();
        }
    }
}
