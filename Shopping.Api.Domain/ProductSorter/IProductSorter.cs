using Shopping.Api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Api.Domain.ProductSorter
{
    public interface IProductSorter
    {
        ProductSorterType Type { get;  }
        Task<List<Product>> Sort(IEnumerable<Product> products);
    }
}
