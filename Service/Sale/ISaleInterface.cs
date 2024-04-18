using Campos_Dealer_Backend.Models;
using Campos_Dealer_Backend.Models.Sales;

namespace Campos_Dealer_Backend.Service.Sale
{
    public interface ISaleInterface
    {
        Task<ServiceResponse<List<SaleModel>>> GetAllSales();
        Task<ServiceResponse<List<SaleModel>>> CreateSale(SaleModel newSale);
        Task<ServiceResponse<List<SaleModel>>> UpdateSale(SaleModel updatedSale);
        Task<ServiceResponse<List<SaleModel>>> DeleteSale(int id);
    }
}
