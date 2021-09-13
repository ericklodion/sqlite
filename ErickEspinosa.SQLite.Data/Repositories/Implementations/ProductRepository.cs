using Dapper;
using ErickEspinosa.SQLite.Data.Repositories.Interfaces;
using ErickEspinosa.SQLite.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErickEspinosa.SQLite.Data.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSession _session;
        public ProductRepository(DbSession session)
        {
            _session = session;
        }

        public async Task Create(Product product)
        {
            var sql = @"INSERT INTO PRODUCT (
                            GUID,
                            NAME,
                            PRICE
                        ) VALUES (
                            @GUID,
                            @NAME,
                            @PRICE
                        )";
            await _session.Connection.ExecuteAsync(sql, product, _session.Transaction);
        }

        public async Task Delete(string guid)
        {
            var sql = "DELETE FROM PRODUCT WHERE GUID = @GUID";
            await _session.Connection.ExecuteAsync(sql, new { guid }, _session.Transaction);
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var sql = "SELECT * FROM PRODUCT";
            return await _session.Connection.QueryAsync<Product>(sql, null, _session.Transaction);
        }
    }
}
