using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Dtos
{
    public class TrolleyDataDto
    {
        public List<ProductDto> Products { get; set; }
        public List<SpecialsDto> Specials { get; set; }
        public List<ProductQuantityDto> Quantities { get; set; }
    }
}
