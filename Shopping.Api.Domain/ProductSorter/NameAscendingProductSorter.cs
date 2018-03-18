using Shopping.Api.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Api.Domain.ProductSorter
{
    public class NameAscendingProductSorter : IProductSorter
    {
        public ProductSorterType Type => ProductSorterType.Ascending;


        public Task<List<Product>> Sort(IEnumerable<Product> products)
        {
            var result =  products.OrderBy(p => p.Name).ToList();
            return Task.FromResult(result);
        }
    }
}
