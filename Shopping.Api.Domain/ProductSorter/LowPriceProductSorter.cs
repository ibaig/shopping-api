using Shopping.Api.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Api.Domain.ProductSorter
{
    public class LowPriceProductSorter : IProductSorter
    {
        public ProductSorterType Type => ProductSorterType.Low;

        public Task<List<Product>> Sort(IEnumerable<Product> products)
        {
            var result =  products.OrderBy(p => p.Price).ToList();
            return Task.FromResult(result);
        }
    }
}
