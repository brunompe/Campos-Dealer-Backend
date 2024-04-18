using Campos_Dealer_Backend.DataContext;
using Campos_Dealer_Backend.Models;
using Campos_Dealer_Backend.Models.Customer;
using Campos_Dealer_Backend.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Campos_Dealer_Backend.Service.Product
{
    public class ProductService : IProductInterface
    {

        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<ProductModel>>> CreateProduct(ProductModel newProduct)
        {
            ServiceResponse<List<ProductModel>> serviceResponse = new ServiceResponse<List<ProductModel>>();

            try
            {
                if (newProduct == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                _context.Add(newProduct);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Products.ToList();
                serviceResponse.Message = "Produto criado com sucesso!";


            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProductModel>>> DeleteProduct(int id)
        { 
            ServiceResponse<List<ProductModel>> serviceResponse = new ServiceResponse<List<ProductModel>>();

            try
            {

                ProductModel product = _context.Products.FirstOrDefault(x => x.Id == id);
            
                if (product == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Produto não encontrado!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Products.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProductModel>>> GetAllProducts()
        {
            ServiceResponse<List<ProductModel>> serviceResponse = new ServiceResponse<List<ProductModel>>();

            try
            {
                serviceResponse.Dados = _context.Products.ToList();

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

        public async Task<ServiceResponse<ProductModel>> GetProductByDescription(string description)
        {
            ServiceResponse<ProductModel> serviceResponse = new ServiceResponse<ProductModel>();

            try
            {
                ProductModel product = _context.Products.FirstOrDefault(x => x.Description == description);

                if (product == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Produto não encontrado!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Dados = product;
                serviceResponse.Message = "Produto encontrado com sucesso!";

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProductModel>>> UpdateProduct(ProductModel updatedProduct)
        {
            ServiceResponse<List<ProductModel>> serviceResponse = new ServiceResponse<List<ProductModel>>();
            
            try
            {
                ProductModel product = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == updatedProduct.Id);

            

                if (product == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Produto não encontrado!";
                    serviceResponse.Success = false;
                }

                _context.Products.Update(updatedProduct);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Products.ToList();

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
