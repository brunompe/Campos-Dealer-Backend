using Campos_Dealer_Backend.DataContext;
using Campos_Dealer_Backend.Models;
using Campos_Dealer_Backend.Models.Customer;
using Campos_Dealer_Backend.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace Campos_Dealer_Backend.Service.Sale
{
    public class SaleService : ISaleInterface
    {

        private readonly ApplicationDbContext _context;
        public SaleService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<SaleModel>>> CreateSale(SaleModel newSale)
        {
            ServiceResponse<List<SaleModel>> serviceResponse = new ServiceResponse<List<SaleModel>>();

            try
            {
                if (newSale == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                newSale.CalculateTotalPrice();

                _context.Add(newSale);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Sales.ToList();
                serviceResponse.Message = "Venda criada com sucesso!";


            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SaleModel>>> DeleteSale(int id)
        {
            ServiceResponse<List<SaleModel>> serviceResponse = new ServiceResponse<List<SaleModel>>();

            try
            {

                SaleModel sale = _context.Sales.FirstOrDefault(x => x.Id == id);

                if (sale == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Venda não encontrada!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Sales.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SaleModel>>> GetAllSales()
        {
            ServiceResponse<List<SaleModel>> serviceResponse = new ServiceResponse<List<SaleModel>>();

            try
            {
                serviceResponse.Dados = _context.Sales.ToList();

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

        public async Task<ServiceResponse<List<SaleModel>>> UpdateSale(SaleModel updatedSale)
        {
            ServiceResponse<List<SaleModel>> serviceResponse = new ServiceResponse<List<SaleModel>>();

            try
            {
                SaleModel sale = _context.Sales.AsNoTracking().FirstOrDefault(x => x.Id == updatedSale.Id);

                if (sale == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Venda não encontrado!";
                    serviceResponse.Success = false;
                }

                sale.UpdateSale(updatedSale.Quantity, updatedSale.ProductPrice);

                _context.Sales.Update(updatedSale);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Sales.ToList();

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
