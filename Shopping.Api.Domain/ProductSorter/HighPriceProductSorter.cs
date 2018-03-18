using Shopping.Api.Domain.Models;
using System.Linq;
using System.Collections.Generic;

namespace Shopping.Api.Domain.ProductSorter
{

    public class HighPriceProductSorter : IProductSorter
    {
        public ProductSorterType Type =>ProductSorterType.High;

        public List<Product> Sort(IEnumerable<Product> products)
        {
            return products.OrderByDescending(p => p.Price).ToList();
        }
    }
}
