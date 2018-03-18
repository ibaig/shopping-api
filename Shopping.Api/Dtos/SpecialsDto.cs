using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Dtos
{
    public class SpecialsDto
    {
        public decimal Total { get; set; }
        public List<ProductQuantityDto> Quantities { get; set; }
    }
}
