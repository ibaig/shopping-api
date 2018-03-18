using Shopping.Api.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Api.Domain.ProductSorter
{
    public class NameDescendingProductSorter : IProductSorter
    {
        public ProductSorterType Type => ProductSorterType.Descending;

        public Task<List<Product>> Sort(IEnumerable<Product> products)
        {
            var result =  products.OrderByDescending(p => p.Name).ToList();
            return Task.FromResult(result);
        }
    }
}
