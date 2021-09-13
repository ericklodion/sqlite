using ErickEspinosa.SQLite.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErickEspinosa.SQLite.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task Create(Product product);
        Task Delete(string guid);
        Task<IEnumerable<Product>> Get();
    }
}
