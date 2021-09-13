using ErickEspinosa.SQLite.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErickEspinosa.SQLite.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task CreateProduct(Product product);
        Task DeleteProduct(string guid);
    }
}
