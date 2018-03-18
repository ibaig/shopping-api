using Shopping.Api.Domain.Models;
using System.Linq;
using System.Collections.Generic;

namespace Shopping.Api.Domain.ProductSorter
{
    public class NameAscendingProductSorter : IProductSorter
    {
        public ProductSorterType Type => ProductSorterType.Ascending;


        public List<Product> Sort(IEnumerable<Product> products)
        {
            return products.OrderBy(p => p.Name).ToList();
        }
    }
}
