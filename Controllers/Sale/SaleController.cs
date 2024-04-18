using Campos_Dealer_Backend.Models.Customer;
using Campos_Dealer_Backend.Models;
using Campos_Dealer_Backend.Service.Customer;
using Campos_Dealer_Backend.Service.Sale;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Campos_Dealer_Backend.Models.Sales;

namespace Campos_Dealer_Backend.Controllers.Sale
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleInterface _saleInterface;
        public SaleController(ISaleInterface saleInterface)
        {
            _saleInterface = saleInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<SaleModel>>>> GetAllSales()
        {
            return Ok(await _saleInterface.GetAllSales());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<SaleModel>>>> CreateSale(SaleModel newSale)
        {
            return Ok(await _saleInterface.CreateSale(newSale));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<SaleModel>>>> UpdateSale(SaleModel updatedSale)
        {
            ServiceResponse<List<SaleModel>> serviceResponse = await _saleInterface.UpdateSale(updatedSale);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<SaleModel>>>> DeleteCustomer(int id)
        {
            ServiceResponse<List<SaleModel>> serviceResponse = await _saleInterface.DeleteSale(id);

            return Ok(serviceResponse);
        }
    }
}
