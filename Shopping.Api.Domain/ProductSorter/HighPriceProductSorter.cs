using Shopping.Api.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Api.Domain.ProductSorter
{

    public class HighPriceProductSorter : IProductSorter
    {
        public ProductSorterType Type =>ProductSorterType.High;

        public Task<List<Product>> Sort(IEnumerable<Product> products)
        {
            var result = products.OrderByDescending(p => p.Price).ToList();
            return Task.FromResult(result);
        }
    }
}
