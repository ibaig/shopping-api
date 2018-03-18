using Shopping.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Api.Domain.ProductSorter
{
    public interface IProductSorter
    {
        List<Product> Sort(IEnumerable<Product> products);
    }
}
