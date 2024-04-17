using Campos_Dealer_Backend.Models;

namespace Campos_Dealer_Backend.Service
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
