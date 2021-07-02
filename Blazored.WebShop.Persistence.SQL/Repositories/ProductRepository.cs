using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Core.Business.Models;
using Blazored.WebShop.Persistence.SQL.Wrappers.Interfaces;

namespace Blazored.WebShop.Persistence.SQL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess _dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Product> GetProducts(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return _dataAccess.QueryList<Product, dynamic>("SELECT * FROM Product", new { }).AsEnumerable();

            return _dataAccess.QueryList<Product, dynamic>("SELECT * FROM Product WHERE Name like '%' + @Filter + '%'",
                new {Filter = filter}).AsEnumerable();
        }

        public Product GetProduct(int id)
        {
            return _dataAccess.QueryFirst<Product, dynamic>("SELECT * FROM Product WHERE ProductId = @ProductId", new { ProductId = id });
        }
    }
}
