using System.Collections.Generic;

namespace Shopping.Api.Domain.Models
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
