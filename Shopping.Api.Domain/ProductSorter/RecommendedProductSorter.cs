using Shopping.Api.Domain.Models;
using System.Linq;
using System.Collections.Generic;

namespace Shopping.Api.Domain.ProductSorter
{
    public class RecommendedProductSorter : IProductSorter
    {
        public List<Product> Sort(IEnumerable<Product> products)
        {
            return products.OrderByDescending(p => p.Name).ToList();
        }
    }
}
