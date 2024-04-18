using Campos_Dealer_Backend.DataContext;
using Campos_Dealer_Backend.Models;
using Campos_Dealer_Backend.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace Campos_Dealer_Backend.Service.Customer
{
    public class CustomerService : ICustomerInterface
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CustomerModel>>> CreateCustomer(CustomerModel newCustomer)
        {
            ServiceResponse<List<CustomerModel>> serviceResponse = new ServiceResponse<List<CustomerModel>>();

            try
            {
                if (newCustomer == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                _context.Add(newCustomer);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Customers.ToList();
                serviceResponse.Message = "Cliente criado com sucesso!";


            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CustomerModel>>> DeleteCustomer(int id)
        {
            ServiceResponse<List<CustomerModel>> serviceResponse = new ServiceResponse<List<CustomerModel>>();

            try
            {

                CustomerModel customer = _context.Customers.FirstOrDefault(x => x.Id == id);

                if (customer == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Cliente não encontrado!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Customers.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CustomerModel>>> GetAllCustomers()
        {
            ServiceResponse<List<CustomerModel>> serviceResponse = new ServiceResponse<List<CustomerModel>>();

            try
            {
                serviceResponse.Dados = _context.Customers.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Message = "Nenhum Dado Encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CustomerModel>> GetCustumerByName(string name)
        {
            ServiceResponse<CustomerModel> serviceResponse = new ServiceResponse<CustomerModel>();

            try
            {
                CustomerModel customer = _context.Customers.FirstOrDefault(x => x.Name == name);

                if (customer == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Cliente não encontrado!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Dados = customer;
                serviceResponse.Message = "Cliente encontrado com sucesso!";

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CustomerModel>>> UpdateCustomer(CustomerModel updatedCustomer)
        {
            ServiceResponse<List<CustomerModel>> serviceResponse = new ServiceResponse<List<CustomerModel>>();

            try
            {
                CustomerModel customer = _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == updatedCustomer.Id);

                if (customer == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Cliente não encontrado!";
                    serviceResponse.Success = false;
                }

                _context.Customers.Update(updatedCustomer);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Customers.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}
