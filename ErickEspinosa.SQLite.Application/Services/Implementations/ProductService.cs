using ErickEspinosa.SQLite.Application.Services.Interfaces;
using ErickEspinosa.SQLite.Data.Repositories.Interfaces;
using ErickEspinosa.SQLite.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErickEspinosa.SQLite.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task CreateProduct(Product product)
        {
            product.Guid = Guid.NewGuid().ToString();

            await _productRepository.Create(product);
        }

        public async Task DeleteProduct(string guid)
        {
            await _productRepository.Delete(guid);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.Get();
        }
    }
}
