using Campos_Dealer_Backend.Models;
using Campos_Dealer_Backend.Models.Product;

namespace Campos_Dealer_Backend.Service.Product
{
    public interface IProductInterface
    {
        Task<ServiceResponse<List<ProductModel>>> GetAllProducts();
        Task<ServiceResponse<List<ProductModel>>> CreateProduct(ProductModel newProduct);
        Task<ServiceResponse<ProductModel>> GetProductByDescription(string description);
        Task<ServiceResponse<List<ProductModel>>> UpdateProduct(ProductModel updatedProduct);
        Task<ServiceResponse<List<ProductModel>>> DeleteProduct(int id);
    }
}
