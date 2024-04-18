using Campos_Dealer_Backend.Models;
using Campos_Dealer_Backend.Models.Customer;

namespace Campos_Dealer_Backend.Service.Customer
{
    public interface ICustomerInterface
    {
        Task<ServiceResponse<List<CustomerModel>>> GetAllCustomers();
        Task<ServiceResponse<List<CustomerModel>>> CreateCustomer(CustomerModel newCustomer);
        Task<ServiceResponse<CustomerModel>> GetCustumerByName(string name);
        Task<ServiceResponse<List<CustomerModel>>> UpdateCustomer(CustomerModel updatedCustomer);
        Task<ServiceResponse<List<CustomerModel>>> DeleteCustomer(int id);
    }
}
