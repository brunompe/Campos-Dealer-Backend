using Campos_Dealer_Backend.Models.Customer;
using Campos_Dealer_Backend.Models;
using Campos_Dealer_Backend.Service.Product;
using Microsoft.AspNetCore.Mvc;
using Campos_Dealer_Backend.Models.Product;

namespace Campos_Dealer_Backend.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInterface _productInterface;
        public ProductController(IProductInterface productInterface)
        {
            _productInterface = productInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> GetAllProducts()
        {
            return Ok(await _productInterface.GetAllProducts());
        }

        [HttpGet("{description}")]
        public async Task<ActionResult<ServiceResponse<List<CustomerModel>>>> GetProductByDescription(string description)
        {
            ServiceResponse<ProductModel> serviceResponse = await _productInterface.GetProductByDescription(description);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> CreateProduct(ProductModel newProduct)
        {
            return Ok(await _productInterface.CreateProduct(newProduct));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> UpdateProduct(ProductModel updatedProduct)
        {
            ServiceResponse<List<ProductModel>> serviceResponse = await _productInterface.UpdateProduct(updatedProduct);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> DeleteProduct(int id)
        {
            ServiceResponse<List<ProductModel>> serviceResponse = await _productInterface.DeleteProduct(id);

            return Ok(serviceResponse);
        }

    }
}
