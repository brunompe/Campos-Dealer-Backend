using Campos_Dealer_Backend.Models;
using Campos_Dealer_Backend.Models.Customer;
using Campos_Dealer_Backend.Service.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Campos_Dealer_Backend.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerInterface _customerInterface;
        public CustomerController(ICustomerInterface customerInterface)
        {
            _customerInterface = customerInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CustomerModel>>>> GetAllCustomers()
        {
            return Ok(await _customerInterface.GetAllCustomers());
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ServiceResponse<List<CustomerModel>>>> GetCustomerByName(string name)
        {
            ServiceResponse<CustomerModel> serviceResponse = await _customerInterface.GetCustumerByName(name);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CustomerModel>>>> CreateCustomer(CustomerModel newCustomer)
        {
            return Ok(await _customerInterface.CreateCustomer(newCustomer));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<CustomerModel>>>> UpdateCustomer(CustomerModel updatedCustomer)
        {
            ServiceResponse<List<CustomerModel>> serviceResponse = await _customerInterface.UpdateCustomer(updatedCustomer);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<CustomerModel>>>> DeleteCustomer(int id)
        {
            ServiceResponse<List<CustomerModel>> serviceResponse = await _customerInterface.DeleteCustomer(id);

            return Ok(serviceResponse);
        }

    }
}
