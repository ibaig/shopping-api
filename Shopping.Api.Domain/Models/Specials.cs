using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Api.Domain.Models
{
    public class Specials
    {
        public decimal Total { get; set; }
        public List<ProductQuantity> Quantities { get; set; }
    }
}
