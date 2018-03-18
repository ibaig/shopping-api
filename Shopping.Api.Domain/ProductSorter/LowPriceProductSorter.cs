using Shopping.Api.Domain.Models;
using System.Linq;
using System.Collections.Generic;

namespace Shopping.Api.Domain.ProductSorter
{
    public class LowPriceProductSorter : IProductSorter
    {
        public ProductSorterType Type => ProductSorterType.Low;

        public List<Product> Sort(IEnumerable<Product> products)
        {
            return products.OrderBy(p => p.Price).ToList();
        }
    }
}
