using Shopping.Api.Domain.Models;
using System.Collections.Generic;

namespace Shopping.Api.Domain.ProductSorter
{
    public interface IProductSorter
    {
        ProductSorterType Type { get;  }
        List<Product> Sort(IEnumerable<Product> products);
    }
}
