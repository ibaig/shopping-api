using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Shopping.Api.Dtos
{
   
    public class TrolleyDataDto
    {
        [DataMember(Name = "products")]
        public List<ProductDto> Products { get; set; }
        [DataMember(Name = "specials")]
        public List<SpecialsDto> Specials { get; set; }
        [DataMember(Name = "quantities")]
        public List<ProductQuantityDto> Quantities { get; set; }
    }
}
