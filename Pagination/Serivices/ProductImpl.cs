using Pagination.Models;
using Pagination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Serivices
{
    public class ProductImpl : IProduct
    {
        private readonly ApplicationContext applicationContext;
        private List<Product> products = new List<Product>();
        public ProductImpl(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            products = applicationContext.Products.ToList();
        }

        public IEnumerable<Product> getProductAll()
        {
            return products;
        }

        public int numberPage(int totalProduct, int limit)
        {
            float numberpage = totalProduct / limit;
            return (int)Math.Ceiling(numberpage);
        }

        public IEnumerable<Product> paginationProduct(int start, int limit)
        {
            var data = (from s in applicationContext.Products select s);
            var dataProduct = data.OrderByDescending(x => x.Id).Skip(start).Take(limit);
            return dataProduct.ToList();
        }

        public int totalProduct()
        {
            return products.Count;
        }
    }
}
